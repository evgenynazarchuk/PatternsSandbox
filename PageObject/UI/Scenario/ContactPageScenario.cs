namespace PageObject
{
    public class ContactPageScenario
    {
        public void CallMeBack()
        {
            var page = new PageBuilder()
                .SetBrowser(BrowserType.Firefox)
                .SetUrl("")
                .SetPort(8080)
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
