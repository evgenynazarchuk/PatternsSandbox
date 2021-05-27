using System;

namespace Decorator
{
    public interface IMessage
    {
        void PrintMessage();
    }

    public abstract class Message
    {
        protected string _message { get; set; }
        public Message(string message) => _message = message;
        public abstract void PrintMessage();
    }

    public class NormalMessage : Message
    {
        public NormalMessage(string message) : base(message) { }
        public override void PrintMessage() => Console.WriteLine(_message);
    }

    public class BeepMessage : Message
    {
        public BeepMessage(string message) : base(message) { }
        public override void PrintMessage()
        {
            Console.Beep();
            Console.WriteLine(_message);
        }
    }

    public class DoubleBeepMessage : BeepMessage
    {
        public DoubleBeepMessage(string message) : base(message) { }
        public override void PrintMessage()
        {
            Console.Beep();
            base.PrintMessage();
        }
    }

    // Декаратор как прокси, позволяет выполнять добавить действия перед вызовом метода объекта и после
    // Наследникам нужно реализовать все методы интерфейса
    // И декоратору нужно реализовать все методы интерфейса
    // Если в интерфейсе много методов, то нужно для каждого метода реализовать обёртку
    // Если декоратор не реализует интерфейс, то лишаемся полиморфизма
    // Можно ли реализовать декоратор без реализации всех пустых обёрток?
    public abstract class MessageDecorator : IMessage
    {
        protected Message _message { get; set; }
        public abstract void PrintMessage();
    }

    public class YellowMessage : MessageDecorator
    {
        public YellowMessage(Message message) => _message = message;

        public override void PrintMessage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            _message.PrintMessage();
            Console.ResetColor();
        }
    }

    public class RedMessage : MessageDecorator
    {
        public RedMessage(Message message) => _message = message;

        public override void PrintMessage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            _message.PrintMessage();
            Console.ResetColor();
        }
    }
}
