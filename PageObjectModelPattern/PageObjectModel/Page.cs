namespace PageObjectModelPattern
{
    public class Page
    {
        public BrowserType BrowserType { get; set; }
        public string Url { get; set; }
        public int Port { get; set; }

        public Page(
            BrowserType browserType = BrowserType.Chrome
            , string url = ""
            , int port = 80
            )
        {
            this.BrowserType = browserType;
            this.Url = url;
            this.Port = port;
        }

        public static PageBuilder CreatePage() => new PageBuilder();

        public HomePage Load
        {
            get => new HomePage();
        }
    }
}
