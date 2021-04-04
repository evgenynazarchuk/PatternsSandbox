namespace SingletonPattern
{
    public class Singleton2
    {
        private static Singleton2 _instance;
        private static object _lock = new object();
        public string Name { get; private set; }

        private Singleton2(string name)
        {
            this.Name = name;
        }

        public static Singleton2 GetInstance(string name)
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new Singleton2(name);
                    }
                }
            }
            return _instance;
        }
    }
}
