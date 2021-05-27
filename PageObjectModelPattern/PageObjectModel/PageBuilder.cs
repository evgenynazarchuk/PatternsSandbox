namespace PageObjectModelPattern
{
    public class PageBuilder
    {
        private Page _page;

        public PageBuilder()
        {
            this._page = new Page();
        }

        public PageBuilder SetBrowser(BrowserType browser)
        {
            this._page.BrowserType = browser;
            return this;
        }

        public PageBuilder SetUrl(string url)
        {
            this._page.Url = url;
            return this;
        }

        public PageBuilder SetPort(int port)
        {
            this._page.Port = port;
            return this;
        }

        public Page Build() => this._page;
    }
}
