using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;
using Telefin.Models;
using Telefin.Models.ViewModels;

namespace Telefin.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        // Creates new users to storage
        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)

        {
            // If the model state is valid i.e if the user entered
            // the details correctly then create that user.
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result =
                    await userManager.CreateAsync(user, model.Password);

                // If the model state is valid and the operations above are successful
                // redirect the user to the index page
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                // If we are unable to create a new user
                // Which might be due to a crappy Model state
                // pass the reason(s) to the associated model
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}