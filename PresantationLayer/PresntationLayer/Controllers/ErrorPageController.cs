using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
