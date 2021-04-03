using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelPattern
{
    public class HomePage
    {
        public MenuBlock Menu
        {
            get => new MenuBlock();
        }

        public string Login { get; private set; }
        public string Password { get; private set; }

        public HomePage SetLogin(string login)
        {
            this.Login = login;
            return this;
        }

        public HomePage SetPassword(string password)
        {
            this.Password = password;
            return this;
        }

        public HomePage Auth
        {
            get => new HomePage();
        }
    }
}
