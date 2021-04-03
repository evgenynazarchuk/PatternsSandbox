using System.Text.Json;

namespace FluentBuilderPattern
{
    public class Product
    {
        // may be implement Inject("") ?
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        // may be implement Inject(7.5f) ?
        public float Net { get; set; }
        public float Gross { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }

        // public Product() { }

        public Product(
            string name = ""
            , string manufacturer = ""
            , float net = 0.0f
            , float gross = 0.0f
            , decimal price = 0.0m
            , bool inStock = false
            )
        {
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Net = net;
            this.Gross = gross;
            this.Price = price;
            this.InStock = inStock;
        }

        public static ProductBuilder CreateProduct() => new ProductBuilder();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
