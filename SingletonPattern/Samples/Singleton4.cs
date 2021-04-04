using System;

namespace SingletonPattern
{
    public class Singleton4
    {
        public DateTime Date { get; private set; }
        public static string Author { get; private set; } = "Evgeny";

        private Singleton4()
        {
            Date = DateTime.Now;
        }

        public static Singleton4 GetInstance() => Nested._instance;

        private class Nested
        {
            static Nested() { }
            internal static readonly Singleton4 _instance = new Singleton4();
        }
    }
}
