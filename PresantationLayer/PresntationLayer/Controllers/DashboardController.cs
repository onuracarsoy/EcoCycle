using BussinesLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public DashboardController(IProductService productService, UserManager<AppUser> userManager, ICompanyService companyService)
        {
            _productService = productService;
            _userManager = userManager;
            _companyService = companyService;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

           
            var context = new Context();
            var company = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);

            //Sales Count
            int productCount = _productService.TProductCount(company.CompanyID);
            ViewBag.ProductCount = productCount;

            //Total Price
            decimal productPriceTotal  = _productService.TProductPriceTotal(company.CompanyID);
            ViewBag.ProductPriceTotal = productPriceTotal;
            return View();
        }

        public async Task<IActionResult> Index2()
        {
    
            return View();
        }
    }
}
