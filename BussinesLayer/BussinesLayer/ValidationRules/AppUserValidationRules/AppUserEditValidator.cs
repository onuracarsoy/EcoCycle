using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserEditValidator : AbstractValidator<AppUserEditDto>
    {
  

        public AppUserEditValidator()
        {


            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be left empty!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Please enter a maximum of 30 characters!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please enter a minimum of 2 characters!");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be left empty!\"");

            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email address!");

         
            RuleFor(x => x.Password).NotEmpty().WithMessage("The password cannot be empty!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Passwords do not match!");

        }

      
    }
}
