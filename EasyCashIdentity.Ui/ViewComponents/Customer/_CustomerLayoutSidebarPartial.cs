using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.ViewComponents.Customer;

public class _CustomerLayoutSidebarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
