using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main()
        {
            // класс декоратор и функциональный класс реализуют идентичный интерфейс
            // класс декоратор содерт функциональный класс для перехвата вызова
            // перехватываюмую функцию/метод возможно следуюет реализовать в виде отдельного интерфейса
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
