﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
{
    public class ContactPageScenario
    {
        public void CallMeBackTest()
        {
            var page = Page.CreatePage()
                .SetBrowser(BrowserType.Firefox)
                .SetUrl("")
                .SetPort(80)
                .Build();

            var scenario = page
                .Load
                .Menu
                .Contact
                .SetPhone("")
                .CallMeBack;
        }
    }
}
