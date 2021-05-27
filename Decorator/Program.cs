using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            var messages = new List<IMessage>()
            {
                new YellowMessage(new DoubleBeepMessage("Hello world")),
                new RedMessage(new NormalMessage("Wow!!!"))
            };

            // полиморфизм
            foreach (var message in messages)
            {
                message.PrintMessage();
            }
        }
    }
}
