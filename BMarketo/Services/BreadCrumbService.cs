using BMarketo.Models;

namespace BMarketo.Services;

public class BreadCrumbService
{
  
        private readonly List<BreadCrumbModel> _breadcrumbs = new()
    {
        new BreadCrumbModel()
        {
           MainTitle = "SHOP",
           HomeLink = "HOME",
           PageTitle = "PRODUCT DETAILS",
           BreadCrumbImageURL = "/images/mc-clothing/Xena-Breadcrumb.webp"


        }
    };
        public BreadCrumbModel GetLatest()
        {
            return _breadcrumbs.LastOrDefault()!;
        }
    }
