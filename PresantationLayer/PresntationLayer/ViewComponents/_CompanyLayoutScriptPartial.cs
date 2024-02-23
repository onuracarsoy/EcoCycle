using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.ViewComponents
{
    public class _CompanyLayoutScriptPartial :  ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
