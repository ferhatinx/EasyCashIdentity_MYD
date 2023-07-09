using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.ViewComponents.Customer;

public class _CustomerLayoutScriptsPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
