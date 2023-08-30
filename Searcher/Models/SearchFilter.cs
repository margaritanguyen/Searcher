namespace Searcher
{
    public class SearchFilter
    {
        private string startPath;
        private string searchMask;
        private int threadCount;

        public string StartPath 
        {
            get { return startPath; }
            set
            {
                if (value != null)
                {
                    startPath = value;
                }
            }
        }

        public string SearchMask
        {
            get { return searchMask; }
            set
            {
                if (value != null)
                {
                    searchMask = value;
                }
            }
        }

        public int ThreadCount
        {
            get { return threadCount; }
            set
            {
                if (value > 0)
                {
                    threadCount = value;
                }
            }
        }

        public SearchFilter() { }

        public SearchFilter(string startPath, string searchMask, int threadCount)
        {
            StartPath = startPath;
            SearchMask = searchMask;
            ThreadCount = threadCount;
        }
    }
}
