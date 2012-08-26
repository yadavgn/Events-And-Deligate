using System;
using System.ComponentModel;

namespace EventsBusines
{
    public class Calculator : IDisposable, INotifyPropertyChanged
    {
        public DataSet _dataSet;

        public DataSet OperationalData
        {
            get { return _dataSet; }
            private set { _dataSet = value; }
        }

        private long _add;

        public long Add
        {
            get { return _add; }
            set { _add = value; OnPropertyChange("Add"); }
        }

        private long _mul;

        public long Mul
        {
            get { return _mul; }
            set { _mul = value; OnPropertyChange("Mul"); }
        }

        private long _div;

        public long Div
        {
            get { return _div; }
            set { _div = value; OnPropertyChange("Div"); }
        }

        private long _sub;

        public long Sub
        {
            get { return _sub; }
            set { _sub = value; OnPropertyChange("Sub"); }
        }

        public Calculator(DataSet dataSet)
        {
            // Attach this
            OperationalData = dataSet;

            // Subscribe to Data change events.
            OperationalData.DataChanged += Addition;
            OperationalData.DataChanged += Subtract;
            OperationalData.DataChanged += Multiplication;
            OperationalData.DataChanged += Division;
        }

        private long Addition()
        {
            var t = OperationalData.A + OperationalData.B;
            System.Console.WriteLine("Added: " + t);
            Add = t;
            return t;
        }

        private long Subtract()
        {
            var t = OperationalData.A - OperationalData.B;
            System.Console.WriteLine("Subtracted: " + t);
            Sub = t;
            return t;
        }

        private long Multiplication()
        {
            var t = OperationalData.A * OperationalData.B;
            System.Console.WriteLine("Multiplication: " + t);
            Mul = t;
            return t;
        }

        private long Division()
        {
            var t = OperationalData.A / OperationalData.B;
            System.Console.WriteLine("Division: " + t);
            Div = t;
            return t;
        }

        #region IDisposable Members

        public void Dispose()
        {
            //Don't Forget to un-subscribe event.
            OperationalData.DataChanged -= Addition;
            OperationalData.DataChanged -= Subtract;
            OperationalData.DataChanged -= Multiplication;
            OperationalData.DataChanged -= Division;
        }

        #endregion IDisposable Members

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var arg = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, arg);
            }
        }

        #endregion INotifyPropertyChanged Members
    }
}