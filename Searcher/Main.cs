using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Searcher
{
    public partial class Main : Form
    {
        CancellationTokenSource cts = null;

        private SearchProgress progress = new SearchProgress();
        private SearchResult result = new SearchResult();
        private SearchFilter filter;

        private readonly object locker = new object();

        public Main()
        {
            InitializeComponent();

            progress.PropertyChanged += UpdateProgressBarState;
            result.PropertyChanged += UpdateFilesCount;

            ThreadPool.GetMinThreads(out int min, out int nmin);
            ThreadPool.GetMaxThreads(out int max, out int nmax);
            numericThreadCount.Minimum = min;
            numericThreadCount.Maximum = max;
        }

        private void UpdateProgressBarState(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            var currentValue = ((SearchProgress)sender).CurrentValue;
            var maxValue = ((SearchProgress)sender).MaxValue;

            switch (propertyName)
            {
                case "SearchProgress":
                    progressBar.Invoke(new Action(delegate () { 
                        progressBar.Maximum = maxValue;
                        progressBar.Value = currentValue;
                    }));
                    break;
            }
        }

        private void UpdateFilesCount(object sender, PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            var filesCount = ((SearchResult)sender).FilesCount;

            switch (propertyName)
            {
                case "FilesCount":
                    lblFoundFilesCount.Invoke(new Action(delegate () { lblFoundFilesCount.Text = filesCount.ToString(); }));
                    break;
            }
        }

        #region FormActions
        private void lblDirectoryPath_Click(object sender, EventArgs e)
        {
            if (directoryBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                lblDirectoryPath.Text = directoryBrowserDialog.SelectedPath;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            btnCancel.Enabled = false;

            var searchPath = lblDirectoryPath.Text;
            var searchMask = tbMask.Text;
            var threadCount = (int)numericThreadCount.Value;

            if (cts != null)
            {
                cts.Cancel();

                await Task.Run(() =>
                {
                    while (true)
                    {
                        ThreadPool.GetAvailableThreads(out int k, out int n);

                        if (k >= filter.ThreadCount - 1) break;
                    }
                });
            }

            cts = new CancellationTokenSource();
            progress.Reset();
            result.ResetFilesCount();
            treeViewFiles.Nodes.Clear();

            filter = new SearchFilter(searchPath, searchMask, threadCount);
            ThreadPool.SetMaxThreads(filter.ThreadCount, filter.ThreadCount);

            var directoryInfo = new DirectoryInfo(filter.StartPath);
            ThreadPool.QueueUserWorkItem(delegate { GetDirectories(directoryInfo); }, cts.Token);

            btnSearch.Enabled = true;
            btnCancel.Enabled = true;
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSearch.Enabled = false;

            if (cts != null)
            {
                cts.Cancel();

                await Task.Run(() =>
                {
                    while (true)
                    {
                        ThreadPool.GetAvailableThreads(out int k, out int n);

                        if (k >= filter.ThreadCount - 1) break;
                    }
                });
            }

            btnCancel.Enabled = true;
            btnSearch.Enabled = true;
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            treeViewFiles.CollapseAll();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            treeViewFiles.ExpandAll();
        }

        private void treeViewFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var nodePath = treeViewFiles.SelectedNode.FullPath;

            if (!Path.HasExtension(nodePath)) return;

            var fullPath = Path.Combine(filter.StartPath, nodePath);

            try
            {
                Process.Start(fullPath);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "Open file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void GetDirectories(DirectoryInfo directoryInfo)
        {
            if (cts.IsCancellationRequested) return;

            if (!directoryInfo.Exists)
            {
                progress.Update(0, 1);
                return;
            }

            GetFiles(directoryInfo);

            try
            {
                var subDirectories = directoryInfo.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(x => !x.Attributes.HasFlag(FileAttributes.Hidden));

                foreach (var directory in subDirectories)
                {
                    if (cts.IsCancellationRequested) break;

                    ThreadPool.QueueUserWorkItem(delegate { GetDirectories(directory); }, cts.Token);
                }

                progress.Update(subDirectories.Count(), 1);
            }
            catch (UnauthorizedAccessException) 
            {
                progress.Update(0, 1);
                return;
            }
        }

        private void GetFiles(DirectoryInfo directoryInfo)
        {
            if (cts.IsCancellationRequested) return;

            try
            {
                var files = directoryInfo.EnumerateFiles(filter.SearchMask, SearchOption.TopDirectoryOnly).Where(x => !x.Attributes.HasFlag(FileAttributes.Hidden));

                if (files.Count() <= 0) return;

                var fileArrays = files.ToArray().Split(100);

                foreach (var fileArray in fileArrays)
                {
                    UpdateForm(fileArray, directoryInfo.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }

        private void UpdateForm(IEnumerable<FileInfo> files, string directoryFullName)
        {
            if (cts.IsCancellationRequested) return;

            lock (locker)
            {
                TreeNode parentNode = null;
                TreeNode directoryNode = null;
                TreeNode subDirectoryNode = null;

                ProcessNodes(directoryFullName, ref parentNode, ref directoryNode, ref subDirectoryNode);

                var fileNodesToAdd = GenerateFileNodes(files);

                if (subDirectoryNode != null)
                {
                    subDirectoryNode.Nodes.AddRange(fileNodesToAdd);
                    directoryNode.ExpandAll();
                }

                if (parentNode == null)
                {
                    if (directoryNode == null)
                    {
                        treeViewFiles.Invoke((Action)delegate () { treeViewFiles.Nodes.AddRange(fileNodesToAdd); });
                    }
                    else
                    {
                        treeViewFiles.Invoke((Action)delegate () { treeViewFiles.Nodes.Add(directoryNode); });
                    }
                }
                else
                {
                    if (directoryNode == null)
                    {
                        treeViewFiles.Invoke((Action)delegate () { parentNode.Nodes.AddRange(fileNodesToAdd); });
                    }
                    else
                    {
                        treeViewFiles.Invoke((Action)delegate () { parentNode.Nodes.Add(directoryNode); });
                    }
                }

                result.AddFilesCount(fileNodesToAdd.Count());
            }
        }

        private void ProcessNodes(string directoryFullName, ref TreeNode parentNode, ref TreeNode directoryNode, ref TreeNode subDirectoryNode)
        {
            var directoryPath = filter.StartPath.TrimEnd('\\');

            var nodeFullPath = directoryFullName.Substring(filter.StartPath.Length);
            var nodeNames = nodeFullPath.Split('\\');

            foreach (var nodeName in nodeNames)
            {
                if (string.IsNullOrEmpty(nodeName)) continue;

                directoryPath += $"\\{nodeName}";

                var nodes = new List<TreeNode>();

                if (directoryNode == null)
                {
                    if (parentNode == null)
                    {
                        nodes = (List<TreeNode>)treeViewFiles.Invoke(new Func<List<TreeNode>>(() => treeViewFiles.Nodes.Find(nodeName, false).ToList()));
                    }
                    else
                    {
                        nodes = parentNode.Nodes.Find(nodeName, false).ToList();
                    }
                }

                if (nodes.Count() > 0)
                {
                    parentNode = nodes[0];
                }
                else
                {
                    var genNode = GenerateDirectoryNode(directoryPath, nodeName);

                    if (directoryNode != null)
                    {
                        var index = subDirectoryNode.Nodes.Add(genNode);
                        subDirectoryNode = subDirectoryNode.Nodes[index];
                    }
                    else
                    {
                        directoryNode = genNode;
                        subDirectoryNode = directoryNode;
                    }
                }
            }
        }

        private TreeNode GenerateDirectoryNode(string directoryPath, string nodeName)
        {
            var directoryIcon = IconHelper.GetFolderIcon(directoryPath);
            int directoryImageIndex = (int)treeViewFiles.Invoke(new Func<int>(() => GetImageIndex(directoryPath, directoryIcon)));
            var resultNode = new TreeNode(nodeName, directoryImageIndex, directoryImageIndex);
            resultNode.Name = nodeName;
            return resultNode;
        }

        private TreeNode[] GenerateFileNodes(IEnumerable<FileInfo> files)
        {
            var fileNodesToAdd = new TreeNode[files.Count()];

            for (int i = 0; i < files.Count(); i++)
            {
                var file = files.ElementAt(i);
                var fileIcon = IconHelper.GetFileIcon(file.FullName);
                int fileImageIndex = (int)treeViewFiles.Invoke(new Func<int>(() => GetImageIndex(file.FullName, fileIcon)));
                fileNodesToAdd[i] = new TreeNode(file.Name, fileImageIndex, fileImageIndex);
            }

            return fileNodesToAdd;
        }

        private int GetImageIndex(string key, Icon icon)
        {
            imageList.Images.Add(key, icon.ToBitmap());
            return imageList.Images.Count - 1;
        }
    }
}
