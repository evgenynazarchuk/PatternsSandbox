using System;

namespace SingletonPattern
{
    public class Singleton3
    {
        private static readonly Singleton3 _instance = new Singleton3();
        public DateTime Date { get; private set; }

        private Singleton3()
        {
            Date = DateTime.Now;
        }

        public static Singleton3 GetInstance() => _instance;
    }
}
