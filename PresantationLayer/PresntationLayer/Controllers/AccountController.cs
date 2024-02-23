using BussinesLayer.Abstract;
using BussinesLayer.ValidationRules.AppUserValidationRules;
using BussinesLayer.ValidationRules.CompanyValidationRules;
using DataAccessLayer.Concrete;
using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.CompanyDto;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public AccountController(UserManager<AppUser> userManager, ICompanyService companyService)
        {
            _userManager = userManager;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            var companyID = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);
            var values = _companyService.TGetById(companyID.CompanyID);
            
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> PersonAccount()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Name = values.Name;
            appUserEditDto.Surname = values.Surname;
            appUserEditDto.Email = values.Email;
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> PersonAccount(AppUserEditDto appUserEditDto)
        {
            AppUserEditValidator av = new AppUserEditValidator();
            ValidationResult results = av.Validate(appUserEditDto);
            if (results.IsValid)
            {
                // Şifre doğruluğunu kontrol et
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var checkPassword = await _userManager.CheckPasswordAsync(user, appUserEditDto.Password);

                if (!checkPassword)
                {
                    ViewBag.checkPassword = "Wrong Password!";
                    return View();
                }

                
      
                user.Surname = appUserEditDto.Surname;
                user.Name = appUserEditDto.Name;
                user.Email = appUserEditDto.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }



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

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(AppUserChangePasswordDto appUserChangePasswordDto)
        {
            AppUserPasswordEditValidator av = new AppUserPasswordEditValidator();
            ValidationResult results = av.Validate(appUserChangePasswordDto);

            if (results.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var isOldPasswordCorrect = await _userManager.CheckPasswordAsync(user, appUserChangePasswordDto.OldPassword);

                if (!isOldPasswordCorrect)
                {
                    ViewBag.isOldPasswordCorrect = "Wrong Password!";
                    return View();
                }

               
                var result = await _userManager.ChangePasswordAsync(user, appUserChangePasswordDto.OldPassword, appUserChangePasswordDto.Password);

                if (result.Succeeded)
                {
                  
                    return RedirectToAction("Index", "Dashboard");
                }

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
