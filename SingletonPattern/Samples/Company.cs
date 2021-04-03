namespace SingletonPattern
{
    public class Company
    {
        private static Company _instance;
        public string Name { get; private set; }

        private Company(string name) 
        {
            this.Name = name;
        }

        public static Company GetInstance(string name)
        {
            if (_instance is null)
            {
                _instance = new Company(name);
            }
            return _instance;
        }
    }
}
