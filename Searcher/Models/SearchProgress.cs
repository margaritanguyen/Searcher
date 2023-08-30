using System.ComponentModel;

namespace Searcher
{
    public class SearchProgress : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private int maxValue { get; set; }
        private int currentValue { get; set; }

        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                if (value >= currentValue)
                {
                    maxValue = value;
                }
            }
        }

        public int CurrentValue
        {
            get { return currentValue; }
            set
            {
                if (value <= maxValue)
                {
                    currentValue = value;
                }
            }
        }

        public SearchProgress()
        {
            CurrentValue = 0;
            MaxValue = 0;
        }

        public SearchProgress(int maxValue, int currentValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
        }

        public void Reset()
        {
            CurrentValue = 0;
            MaxValue = 0;
            NotifyPropertyChanged("SearchProgress");
        }

        public void Update(int incMaxValue, int incValue)
        {
            MaxValue += incMaxValue;
            CurrentValue += incValue;
            NotifyPropertyChanged("SearchProgress");
        }
    }
}
