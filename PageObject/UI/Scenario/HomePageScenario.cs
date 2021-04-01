using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class HomePageScenario
    {
        public void Login()
        {
            var page = Page.CreatePage()
                .SetBrowser(BrowserType.Chrome)
                .SetUrl("")
                .Build();

            var scenario = page
                .Load
                .SetLogin("")
                .SetPassword("")
                .Auth;
        }
    }
}
