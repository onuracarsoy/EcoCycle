using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserPasswordEditValidator :  AbstractValidator<AppUserChangePasswordDto>
    {

        public AppUserPasswordEditValidator() 
        {
            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("Current password cannot be empty!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("New password cannot be empty!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Passwords do not match!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password confirmation field cannot be empty!");

        }
    }
}
