using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.ViewComponents.Customer;

public class _CustomerLayoutNavbarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
