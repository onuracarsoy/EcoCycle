using BussinesLayer.Abstract;
using BussinesLayer.ValidationRules.CompanyValidationRules;
using BussinesLayer.ValidationRules.ProductValidationRules;
using DataAccessLayer.Concrete;
using DtoLayer.Dtos.CompanyDto;
using DtoLayer.Dtos.ProductDto;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using X.PagedList;

namespace PresantationLayer.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public ProductController(IProductService productService, UserManager<AppUser> userManager, ICompanyService companyService)
        {
            _productService = productService;
            _userManager = userManager;
            _companyService = companyService;
        }

        public async Task<IActionResult> Index(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType, int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

         
            var context = new Context();
            var company = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);

            if (company != null)
            {
            
                var values = _productService.TGetProductsFilters(ProductName, ProductPrice, ProductCount, ProductWeigth, ProductWeigthType).Where(x => x.CompanyID == company.CompanyID && x.Status == false).ToList().ToPagedList(page,8);

                if (values != null)
                {
                    ViewBag.ProductName = ProductName;
                    ViewBag.ProductPrice = ProductPrice;
                    ViewBag.ProductCount = ProductCount;
                    ViewBag.ProductWeigth = ProductWeigth;
                    ViewBag.ProductWeigthType = ProductWeigthType;
                    return View(values);
                }
                else
                {
                    ViewBag.ProductIsNull = "No Products Found";
                    return View();
                }

            }
            else
            {
                ViewBag.CompanyIsNull = "You Don't Have a Company Yet";
                return View();
            }

        }

        public async Task<IActionResult> Index2(string ProductName, decimal? ProductPrice, int? ProductCount, decimal? ProductWeigth, string ProductWeigthType, int page = 1)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

        
            var context = new Context();
            var company = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);

            if (company != null)
            {
             
                var values = _productService.TGetProductsFilters(ProductName, ProductPrice, ProductCount, ProductWeigth, ProductWeigthType).Where(x => x.CompanyID == company.CompanyID && x.Status == true).ToList().ToPagedList(page, 8);

                if (values != null)
                {
                    ViewBag.ProductName = ProductName;
                    ViewBag.ProductPrice = ProductPrice;
                    ViewBag.ProductCount = ProductCount;
                    ViewBag.ProductWeigth = ProductWeigth;
                    ViewBag.ProductWeigthType = ProductWeigthType;
                    return View(values);
                }
                else
                {
                    ViewBag.ProductIsNull = "No Products Found";
                    return View();
                }

            }
            else
            {
                ViewBag.CompanyIsNull = "You Don't Have a Company Yet";
                return View();
            }

        }


        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {

            ProductValidator pv = new ProductValidator();
            ValidationResult results = pv.Validate(product);
            if (results.IsValid)
            {
                var context = new Context();
                var values = new Product();
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

              

                var company = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);


                values.ProductName = product.ProductName;
                values.ProductCount = product.ProductCount;
                values.ProductPrice = product.ProductPrice;
                values.ProductWeigth = product.ProductWeigth;
                values.ProductWeigthType = product.ProductWeigthType;
                values.ProductDescription = product.ProductDescription;
                values.Date = DateTime.Now;
                values.Status = true;
                values.CompanyID = company.CompanyID;


                _productService.TInsert(values);
                context.SaveChanges();

                return RedirectToAction("Index", "Product");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _productService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ProductValidator pv = new ProductValidator();
            ValidationResult result = pv.Validate(product);

            if (result.IsValid)
            {


                _productService.TUpdate(product);
                return RedirectToAction("Index","Product");
            }
            else
            {

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return RedirectToAction("Index","Product");
        }
    }
}


