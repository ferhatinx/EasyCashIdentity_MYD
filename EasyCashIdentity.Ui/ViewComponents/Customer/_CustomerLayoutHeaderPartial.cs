using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentity.Ui.ViewComponents.Customer;
public class _CustomerLayoutHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
          return View();
    }

}
