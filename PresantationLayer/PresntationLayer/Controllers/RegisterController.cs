using BussinesLayer.Abstract;
using BussinesLayer.ValidationRules.AppUserValidationRules;
using BussinesLayer.ValidationRules.CompanyValidationRules;
using DataAccessLayer.Concrete;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.CompanyDto;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public RegisterController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ICompanyService companyService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            AppUserRegisterValidator av = new AppUserRegisterValidator();
            ValidationResult results = av.Validate(appUserRegisterDto);

            if (results.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(appUserRegisterDto.Email);
                    if (user != null)
                    {
                        ModelState.AddModelError("Email", "This email is already in use.");
                        return View(appUserRegisterDto);
                    }

                    var appUser = new AppUser
                    {
                        UserName = appUserRegisterDto.Username,
                        Name = appUserRegisterDto.Name,
                        Surname = appUserRegisterDto.Surname,
                        Email = appUserRegisterDto.Email
                    };

                    var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                    if (result.Succeeded)
                    {
                        TempData["AppUserID"] = appUser.Id;
                        return RedirectToAction("Index2", "Register");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(appUserRegisterDto);
        }

        [HttpGet]
        public IActionResult Index2()
        {
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Index2(Company company)
        {
            CompanyValidator cv = new CompanyValidator();
            ValidationResult results = cv.Validate(company);
            if (results.IsValid)
            {
                var context = new Context();
                var values = new Company();

                var appUserID = TempData["AppUserID"];

               

                values.CompanyName = company.CompanyName;
                values.Country = company.Country;
                values.City = company.City;
                values.CompanyMail = company.CompanyMail;
                values.CompanyPhoneNumber = company.CompanyPhoneNumber;
                values.AppUserID = (int)appUserID;

                _companyService.TInsert(values);
                context.SaveChanges();

                return RedirectToAction("Index", "Login");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
