using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {

        public AppUserLoginValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email address!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("The password cannot be empty!");
        }
    }
}
