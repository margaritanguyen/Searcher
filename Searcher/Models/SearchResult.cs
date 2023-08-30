using System.ComponentModel;

namespace Searcher
{
    public class SearchResult : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private int filesCount { get; set; }

        public int FilesCount
        {
            get { return filesCount; }
        }

        public void ResetFilesCount()
        {
            filesCount = 0;
            NotifyPropertyChanged("FilesCount");
        }

        public void AddFilesCount(int addCount)
        {
            filesCount += addCount;
            NotifyPropertyChanged("FilesCount");
        }
    }
}
