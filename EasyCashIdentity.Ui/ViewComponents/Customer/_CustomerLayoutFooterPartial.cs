using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.ViewComponents.Customer;

public class _CustomerLayoutFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
