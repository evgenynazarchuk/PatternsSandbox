using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>();
        public Guid Id { get; private set; }

        private SingletonLazy() => this.Id = Guid.NewGuid();
        public static SingletonLazy GetInstance()
        {
            return _instance.Value;
        }
    }
}
