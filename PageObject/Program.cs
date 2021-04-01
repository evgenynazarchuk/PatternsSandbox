using System;

namespace PageObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var homePageTest = new HomePageTest();
            homePageTest.Login();

            var contactPageTest = new ContactPageTest();
            contactPageTest.CallMeBackTest();
        }
    }
}
