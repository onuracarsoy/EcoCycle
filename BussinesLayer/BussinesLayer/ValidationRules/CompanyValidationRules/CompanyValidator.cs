using DtoLayer.Dtos.AppUserDtos;
using DtoLayer.Dtos.CompanyDto;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.CompanyValidationRules
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("The name field cannot be left empty!");
            RuleFor(x => x.CompanyName).MaximumLength(30).WithMessage("Please enter a maximum of 30 characters!");
            RuleFor(x => x.CompanyName).MinimumLength(2).WithMessage("Please enter a minimum of 2 characters!");

            RuleFor(x => x.Country).NotEmpty().WithMessage("The country field cannot be left empty!");

            RuleFor(x => x.City).NotEmpty().WithMessage("The city field cannot be left empty!");

            RuleFor(x => x.CompanyPhoneNumber).NotEmpty().WithMessage("The phone number field cannot be left empty!");


            RuleFor(x => x.CompanyMail).NotEmpty().WithMessage("The email field cannot be left empty!");
            RuleFor(x => x.CompanyMail).EmailAddress().WithMessage("Please enter a valid email address!");
        }
    }
}
