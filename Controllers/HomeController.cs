using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EarlyMan.Models;
using EarlyMan.Models.ViewModels;

namespace EarlyMan.Controllers
{
    public class HomeController : Controller
    {
        private IPrintRepository printRepo;
        private IPromotionRepository promoRepo;
        private HomepageItems homePageVM;

        public HomeController(IPrintRepository print, IPromotionRepository promo)
        {
            printRepo = print;
            promoRepo = promo;
            homePageVM = new HomepageItems
            {
                printRepository = printRepo,
                promotionRepository = promoRepo
            };
        }

        [Authorize]
        public ViewResult Index() => View(homePageVM);

        public ViewResult ProductShowcase() => View(homePageVM);

        public ViewResult ItemSummary() => View();
    }
}