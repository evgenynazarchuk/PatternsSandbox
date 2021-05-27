using System;
using System.Threading;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var company1 = Singleton1.GetInstance("Company 1");
            var company2 = Singleton1.GetInstance("Company 2");
            Console.WriteLine(company1.Name); // 1
            Console.WriteLine(company2.Name); // 1

            //
            (new Thread(() =>
            {
                var os1 = Singleton2.GetInstance("Windows 10");
                Console.WriteLine(os1.Name);
            })).Start();
            var os2 = Singleton2.GetInstance("Ubuntu");
            Console.WriteLine(os2.Name);

            //
            (new Thread(() =>
            {
                var createDate1 = Singleton3.GetInstance();
                Console.WriteLine(createDate1.Date.Ticks);
            })).Start();
            var createDate2 = Singleton3.GetInstance();
            Console.WriteLine(createDate2.Date.Ticks);

            //
            (new Thread(() =>
            {
                var modifyDate1 = Singleton4.GetInstance();
                Console.WriteLine(modifyDate1.Date.Ticks);
            })).Start();
            var modifyDate2 = Singleton4.GetInstance();
            Console.WriteLine(modifyDate2.Date.Ticks);

            //
            (new Thread(() =>
            {
                var lazy1 = Singleton5.GetInstance();
                Console.WriteLine(lazy1.Id);
            })).Start();
            var lazy2 = Singleton5.GetInstance();
            Console.WriteLine(lazy2.Id);
        }
    }
}
