using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EarlyMan.Models;
using EarlyMan.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace EarlyMan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private HomepageItems homePageVM { get; set; }
        private HttpContext Cxt { get; set; }

        public HomeController(IPrintRepository print, IPromotionRepository promo)
        {
            homePageVM = new HomepageItems
            {
                PrintRepository = print,
                PromotionRepository = promo,
                Context = Cxt
            };
        }

        [AllowAnonymous]
        public ViewResult Index() => View(homePageVM);

        [AllowAnonymous]
        public ViewResult ProductShowcase() => View(homePageVM);

        [AllowAnonymous]
        [HttpGet]
        public ViewResult ShoppingCart() => View();

        [Authorize]
        [HttpPost]
        public ActionResult Checkout() => View();

        [AllowAnonymous]
        public ViewResult Error() => View();
    }
}