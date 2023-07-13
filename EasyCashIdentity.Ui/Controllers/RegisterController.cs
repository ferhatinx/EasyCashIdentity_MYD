
using Dto.Dtos;
using Entitiy.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
                Random random = new();
                AppUser appUser = new()
                {
                 
                    UserName = dto.Username,
                    Email = dto.Email,
                    Surname = dto.Surname,
                    Name = dto.Name,
                    City = "aaaa",
                    District = "aaaa",
                    ImageUrl = "aaaa",
                    ConfirmCode = random.Next(100000, 1000000)
                };
                var result = await _userManager.CreateAsync(appUser, dto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "ferhatinx@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", dto.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = $"Kayıt işlemi gerçekleştirmek için onay kodunuz:{appUser.ConfirmCode} ";
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient client = new();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("ferhatinx@gmail.com", "kpohfyipalzlapdg");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Mail"] = appUser.Email;
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
