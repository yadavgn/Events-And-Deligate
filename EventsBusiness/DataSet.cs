namespace EventsBusines
{
    public class DataSet
    {
        // Delegate to handle Data Change events.
        public delegate long DataChangedHandler();

        private int _A;

        public int A
        {
            get { return _A; }
            set
            {
                _A = value;
                OnDataChangedEvent();
            }
        }

        private int _B;

        public int B
        {
            get { return _B; }
            set
            {
                _B = value;
                OnDataChangedEvent();
            }
        }

        private void OnDataChangedEvent()
        {
            if (DataChanged != null)
                DataChanged();
        }

        //Events
        public event DataChangedHandler DataChanged;
    }
}