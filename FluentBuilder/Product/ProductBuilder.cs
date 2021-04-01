using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    public class ProductBuilder
    {
        private Product _product;

        public ProductBuilder()
        {
            this._product = new Product();
        }

        public ProductBuilder SetName(string name)
        {
            this._product.Name = name;
            return this;
        }

        public ProductBuilder SetManufacturer(string manufacturer)
        {
            this._product.Manufacturer = manufacturer;
            return this;
        }

        public ProductBuilder SetNet(float net)
        {
            this._product.Net = net;
            return this;
        }

        public ProductBuilder SetGross(float gross)
        {
            this._product.Gross = gross;
            return this;
        }

        public ProductBuilder SetPrice(decimal price)
        {
            this._product.Price = price;
            return this;
        }

        public ProductBuilder InStock
        {
            get
            {
                this._product.InStock = true;
                return this;
            }
        }

        public Product Build() => this._product;
    }
}
