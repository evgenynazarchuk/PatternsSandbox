namespace PageObjectModelPattern
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
