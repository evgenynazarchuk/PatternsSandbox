namespace SingletonPattern
{
    public class OS
    {
        private static OS _instance;
        private static object _lock = new object();
        public string Name { get; private set; }

        private OS(string name)
        {
            this.Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new OS(name);
                    }
                }
            }
            return _instance;
        }
    }
}
