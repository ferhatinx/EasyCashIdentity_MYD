using EasyCashIdentity.Ui.Models;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
	public class ConfirmMailController : Controller

	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public  IActionResult Index()
		{
            var value = TempData["Mail"];
            ViewBag.v = value;
            
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel model)
        {
		
            var user = await _userManager.FindByEmailAsync(model.Mail);
            if(user.ConfirmCode == model.ConfirmCode)
            {
                return RedirectToAction("Index","MyProfileController");
            }
            return View(model);
        }
    }
}
