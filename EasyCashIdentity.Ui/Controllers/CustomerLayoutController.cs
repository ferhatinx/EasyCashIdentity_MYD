using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.Controllers
{
    public class CustomerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
