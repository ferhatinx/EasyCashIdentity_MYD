using Dto.Dtos;
using Entitiy.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto()
            {
                Name = values.Name,
                Surname = values.Surname,
                PhoneNumber = values.PhoneNumber,
                Email = values.Email,
                City = values.City,
                District = values.District,
                ImageUrl = values.ImageUrl,
            };
            
            return View(appUserEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto dto)
        {
            if(dto.Password == dto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = dto.PhoneNumber;
                user.Surname = dto.Surname;
                user.City = dto.City;
                user.District = dto.District;
                user.Name = dto.Name;
                user.ImageUrl = "test";
                user.Email = dto.Email;
                user.PasswordHash=_userManager.PasswordHasher.HashPassword(user,dto.Password);
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Login"); 
                }
            }
            return View();
        }
    }
}
