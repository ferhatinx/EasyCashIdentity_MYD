
using Dto.Dtos;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto dto)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    Id=Guid.NewGuid().ToString(),
                    UserName = dto.Username,
                    Email = dto.Email,
                    Surname = dto.Surname,
                    Name = dto.Name,
                    City="aaaa",
                    District="aaaa",
                    ImageUrl="aaaa"
                };
                var result = await _userManager.CreateAsync(appUser, dto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","ConfirmMail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
