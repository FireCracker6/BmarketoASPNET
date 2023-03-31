using BMarketo.Models;


namespace BMarketo.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMARKETO SHOP",
            Title = "Exclusive Chair gold Collection",
            ImageUrl = "images/placeholders/625x647.svg",
            Button = new LinkButtonModel()
            {
                Content = "SHOP NOW",
                Url = "/ProductDetails"
            }

        },
          new ShowcaseModel()
        {
            Ingress = "BMARKETO THE BEST A PERSON CAN GET",
            Title = "Now with ALL new MC CLOTHING",
            ImageUrl = "images/mc-clothing/mc-cover.webp",
            Button = new LinkButtonModel()
            {
                Content = "SHOP NOW",
                Url = "/ProductDetails"
            }

        }
    };

    public ShowcaseModel GetLatest()
    {
        return _showcases.LastOrDefault()!; 
    }
}
