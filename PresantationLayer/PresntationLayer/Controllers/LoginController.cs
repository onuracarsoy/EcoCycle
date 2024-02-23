using BussinesLayer.ValidationRules.AppUserValidationRules;
using BussinesLayer.ValidationRules.ProductValidationRules;
using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Net.Mail;

namespace PresantationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto appUserLoginDto)
        {

            var av = new AppUserLoginValidator();
            ValidationResult results = av.Validate(appUserLoginDto);

            if (results.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(appUserLoginDto.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, appUserLoginDto.Password, false, true);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {

                        ViewBag.Wrong1 = "Email or password is incorrect!";
                        return View(appUserLoginDto);
                    }
                }
                else
                {

                    
                    ViewBag.Wrong1 = "Email or password is incorrect!";
                    return View(appUserLoginDto);
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {

                         ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(appUserLoginDto);
        }

      

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");


        }
    }
}
