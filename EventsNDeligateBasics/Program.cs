using EventsBusines;

namespace EventsNDeligateBasics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new DataSet();
            data.A = 3;
            data.B = 4;

            var calculator = new Calculator(data);

            data.A = 6; // This will

            // Unsubscribe from all events.
            calculator.Dispose();
        }
    }
}