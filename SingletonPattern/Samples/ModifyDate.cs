using System;

namespace SingletonPattern
{
    public class ModifyDate
    {
        public DateTime Date { get; private set; }
        public static string Author { get; private set; } = "Evgeny";

        private ModifyDate()
        {
            Date = DateTime.Now;
        }

        public static ModifyDate GetInstance() => Nested._instance;

        private class Nested
        {
            static Nested() { }
            internal static readonly ModifyDate _instance = new ModifyDate();
        }
    }
}
