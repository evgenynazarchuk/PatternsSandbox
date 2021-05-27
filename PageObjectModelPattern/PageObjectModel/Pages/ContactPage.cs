namespace PageObjectModelPattern
{
    public class ContactPage
    {
        public MenuBlock Menu
        {
            get => new MenuBlock();
        }

        public string Phone { get; private set; }

        public ContactPage SetPhone(string phone)
        {
            this.Phone = phone;
            return this;
        }

        public ContactPage CallMeBack
        {
            get => new ContactPage();
        }
    }
}
