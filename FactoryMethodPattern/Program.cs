using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new AirplanFactory();
            var airplan = factory.Create();

            factory = new CarFactory();
            var car = factory.Create();

            factory = new ScooterFactory();
            var scooter = factory.Create();

            Console.WriteLine(airplan.Model);
            Console.WriteLine(car.Model);
            Console.WriteLine(scooter.Model);
        }
    }
}
