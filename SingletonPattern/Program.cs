using System;
using System.Threading.Tasks;
using System.Threading;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var company1 = Company.GetInstance("Company 1");
            var company2 = Company.GetInstance("Company 2");
            Console.WriteLine(company1.Name); // 1
            Console.WriteLine(company2.Name); // 1

            //
            (new Thread(() =>
            {
                var os1 = OS.GetInstance("Windows 10");
                Console.WriteLine(os1.Name);
            })).Start();
            var os2 = OS.GetInstance("Ubuntu");
            Console.WriteLine(os2.Name);

            //
            (new Thread(() =>
            {
                var createDate1 = CreateDate.GetInstance();
                Console.WriteLine(createDate1.Date.Ticks);
            })).Start();
            var createDate2 = CreateDate.GetInstance();
            Console.WriteLine(createDate2.Date.Ticks);

            //
            (new Thread(() =>
            {
                var modifyDate1 = ModifyDate.GetInstance();
                Console.WriteLine(modifyDate1.Date.Ticks);
            })).Start();
            var modifyDate2 = ModifyDate.GetInstance();
            Console.WriteLine(modifyDate2.Date.Ticks);

            //
            (new Thread(() =>
            {
                var lazy1 = SingletonLazy.GetInstance();
                Console.WriteLine(lazy1.Id);
            })).Start();
            var lazy2 = SingletonLazy.GetInstance();
            Console.WriteLine(lazy2.Id);
        }
    }
}
