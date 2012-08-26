using System.ComponentModel;
using EventsBusines;

namespace Events_WPFApp
{
    internal class CalculatorViewModel : INotifyPropertyChanged
    {
        private DataSet _dataSet;

        public DataSet CalculationData
        {
            get { return _dataSet; }
            private set { _dataSet = value; }
        }

        private Calculator _calculator;

        public Calculator Calculator
        {
            get { return _calculator; }
            set { _calculator = value; }
        }

        public CalculatorViewModel()
        {
            CalculationData = new DataSet();
            CalculationData.A = 45;
            CalculationData.B = 9;
            Calculator = new Calculator(CalculationData);
            Calculator.Add = 12;
            Calculator.Sub = 21;
            Calculator.Mul = 12;
            Calculator.Div = 21;
        }

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