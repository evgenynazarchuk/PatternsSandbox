using System;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            var product1 = new Product();
            product1.Name = "One";
            product1.Price = 100.50m;
            //
            var product2 = new Product(name: "Five", inStock: true);

            // fluent builder pattern (for example: gatling perfomance test, page object)
            var product3 = new ProductBuilder()
                .SetName("Two")
                .Build();
            var product4 = new ProductBuilder()
                .SetName("Three")
                .SetNet(7.5f)
                .SetPrice(300.99m)
                .Build();
            var product5 = Product.CreateProduct()
                .SetName("Four")
                .SetManufacturer("M1")
                .SetNet(10.1f)
                .SetGross(11.5f)
                .InStock
                .SetPrice(400.99m)
                .Build();

            Console.WriteLine(product1);
            Console.WriteLine(product2);
            Console.WriteLine(product3);
            Console.WriteLine(product4);
            Console.WriteLine(product5);
        }
    }
}
