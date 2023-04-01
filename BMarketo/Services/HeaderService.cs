using BMarketo.Models;

namespace BMarketo.Services
{
    public class HeaderService
    {
        private readonly List<HeaderModel> _views = new()
        {
            new HeaderModel()
            {
                Logo = "https://saxeit.se/images/logo.svg",
                HomeLink = "HOME",
                ProductsLink = "PRODUCTS",
                ContactsLink = "CONTACTS",
                LoginLink = "LOGIN"
            }
        };
      public HeaderModel GetLatest() 
        { 
            return _views.LastOrDefault()!;
        }
    }
}
