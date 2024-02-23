using DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {

        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The name field cannot be left empty!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Please enter a maximum of 30 characters!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please enter a minimum of 2 characters!");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("The surname field cannot be left empty!");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Please enter a maximum of 30 characters!");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Please enter a minimum of 2 characters!");

            RuleFor(x => x.Username).NotEmpty().WithMessage("The username field cannot be left empty!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email address!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("The password cannot be empty!");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password confirmation field cannot be empty!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Passwords do not match!");


        }

        private bool PasswordMustContainRequirements(string password)
        {
            // Şifre, en az bir büyük harf, bir küçük harf ve bir rakam içermelidir
            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit);
        }
    }
}
