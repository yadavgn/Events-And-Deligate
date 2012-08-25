using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsNDeligateBasics
{
    public class Calculator : IDisposable
    {

        public DataSet _dataSet;
        public DataSet OperationalData
        {
            get { return _dataSet; }
            private set { _dataSet = value; }
        }

        public Calculator(DataSet dataSet)
        {
            // Attach this
            OperationalData = dataSet;
            
            // Subscribe to Data change events.
            OperationalData.DataChanged += Add; 
            OperationalData.DataChanged += Subtract;
            OperationalData.DataChanged += Multiplication;
            OperationalData.DataChanged += Division;
        }

        private long Add()
        {
            var t = OperationalData.A+OperationalData.B;
            System.Console.WriteLine("Added: "+t);
            return t;
        }
        private long Subtract()
        {
            var t = OperationalData.A - OperationalData.B ;
            System.Console.WriteLine("Subtracted: "+ t);
            return t;
        }

        private long Multiplication()
        {
            var t = OperationalData.A * OperationalData.B;
            System.Console.WriteLine("Multiplication: " + t);
            return t;
        }

        private long Division()
        {
            var t = OperationalData.A * OperationalData.B;
            System.Console.WriteLine("Division: " + t);
            return t;
        }


        #region IDisposable Members

        public void Dispose()
        {
            //Don't Forget to un-subscribe the event.
            OperationalData.DataChanged -= Add;
            OperationalData.DataChanged -= Subtract;
            OperationalData.DataChanged -= Multiplication;
            OperationalData.DataChanged -= Division;
        }

        #endregion
    }
}
