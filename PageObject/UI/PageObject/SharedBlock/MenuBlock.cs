using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class MenuBlock
    {
        public HomePage HomePage
        {
            get => new HomePage();
        }

        public AboutPage About
        {
            get => new AboutPage();
        }

        public ContactPage Contact
        {
            get => new ContactPage();
        }
    }
}
