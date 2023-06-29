using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
