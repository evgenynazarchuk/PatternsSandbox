namespace Decorator
{
    class Program
    {
        static void Main()
        {
            var yellowDoubleBeep = new YellowMessage(new DoubleBeepMessage("Hello world"));
            yellowDoubleBeep.PrintMessage();
        }
    }
}
