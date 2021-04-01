using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class AboutPage
    {
        public MenuBlock Menu
        {
            get => new MenuBlock();
        }

        public string Text
        {
            get => "text qwerty";
        }
    }
}
