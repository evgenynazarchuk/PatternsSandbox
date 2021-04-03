using System;

namespace SingletonPattern
{
    public class CreateDate
    {
        private static readonly CreateDate _instance = new CreateDate();
        public DateTime Date { get; private set; }

        private CreateDate()
        {
            Date = DateTime.Now;
        }

        public static CreateDate GetInstance() => _instance;
    }
}
