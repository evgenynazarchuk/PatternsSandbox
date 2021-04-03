namespace PageObjectModelPattern
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
