using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    public class MyAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
