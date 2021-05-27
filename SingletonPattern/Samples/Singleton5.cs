using System;

namespace SingletonPattern
{
    public class Singleton5
    {
        private static readonly Lazy<Singleton5> _instance = new Lazy<Singleton5>(() => new Singleton5());
        public Guid Id { get; private set; }

        private Singleton5() => this.Id = Guid.NewGuid();
        public static Singleton5 GetInstance()
        {
            return _instance.Value;
        }
    }
}
