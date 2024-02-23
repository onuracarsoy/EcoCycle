using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.ViewComponents
{
    public class _CompanyLayoutHeaderPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
