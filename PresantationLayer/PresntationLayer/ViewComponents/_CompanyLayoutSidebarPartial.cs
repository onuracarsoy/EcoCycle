using BussinesLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresantationLayer.ViewComponents
{
    public class _CompanyLayoutSidebarPartial : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICompanyService _companyService;

        public _CompanyLayoutSidebarPartial(UserManager<AppUser> userManager, ICompanyService companyService)
        {
            _userManager = userManager;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            var companyID = context.Companies.FirstOrDefault(x => x.AppUserID == user.Id);
            var values = _companyService.TGetById(companyID.CompanyID);

            return View(values);
        }
    }
}
