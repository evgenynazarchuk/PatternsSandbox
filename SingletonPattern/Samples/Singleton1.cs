namespace SingletonPattern
{
    public class Singleton1
    {
        private static Singleton1 _instance;
        public string Name { get; private set; }

        private Singleton1(string name) 
        {
            this.Name = name;
        }

        public static Singleton1 GetInstance(string name)
        {
            if (_instance is null)
            {
                _instance = new Singleton1(name);
            }
            return _instance;
        }
    }
}
