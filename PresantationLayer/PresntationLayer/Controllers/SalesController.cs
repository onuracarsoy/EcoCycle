using BussinesLayer.Abstract;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresantationLayer.Models;
using X.PagedList;

namespace PresantationLayer.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;
        private readonly UserManager<AppUser> _userManager;

        public SalesController(IProductService productService, ICompanyService companyService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _companyService = companyService;
            _userManager = userManager;
        }

      
        public IActionResult Index(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType, int page = 1)
        {
            var values = _productService.TGetProductsFilters( ProductName, ProductPrice , ProductCount, ProductWeigth, ProductWeigthType).ToPagedList(page,7);
            ViewBag.ProductName = ProductName;
            ViewBag.ProductPrice = ProductPrice;
            ViewBag.ProductCount = ProductCount;
            ViewBag.ProductWeigth = ProductWeigth;
            ViewBag.ProductWeigthType = ProductWeigthType;
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ResultSalesViewModel resultSalesViewModel = new ResultSalesViewModel();
            var product = _productService.TGetById(id);
            var company = _companyService.TGetById(product.CompanyID);



            resultSalesViewModel.ProductName = product.ProductName;
            resultSalesViewModel.ProductDescription = product.ProductDescription;
            resultSalesViewModel.ProductCount = product.ProductCount;
            resultSalesViewModel.ProductWeigth = product.ProductWeigth;
            resultSalesViewModel.ProductWeigthType = product.ProductWeigthType;
            resultSalesViewModel.ProductPrice = product.ProductPrice;
            resultSalesViewModel.Date = product.Date;
            resultSalesViewModel.Status = product.Status;

            resultSalesViewModel.CompanyName = company.CompanyName;
            resultSalesViewModel.Country = company.Country;
            resultSalesViewModel.City = company.City;
            resultSalesViewModel.CompanyMail = company.CompanyMail;
            resultSalesViewModel.CompanyPhoneNumber = company.CompanyPhoneNumber;

            return View(resultSalesViewModel);
        }

        [HttpGet]
        public IActionResult Purchase(int id)
        {      
            var product = _productService.TGetById(id);
            var company = _companyService.TGetById(product.CompanyID);

            ViewBag.ProductID = product.ProductID;
            ViewBag.ProductName = product.ProductName;
            ViewBag.ProductPrice = product.ProductPrice;

            ViewBag.CompanyName = company.CompanyName;
            ViewBag.Mail = company.CompanyMail;
            ViewBag.Phone = company.CompanyPhoneNumber;

            return View();
     
        }
        //[HttpPost]
        //public IActionResult Purchase(CreditCardViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // İlgili işlemleri gerçekleştir
        //        return RedirectToAction("PurchaseSuccessful", "Sales", new { id = model.ProductID });
        //    }

        //    return View(model);


        //}




        public IActionResult PurchaseSuccessful(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);

            

            return View();

        }
    }
}
