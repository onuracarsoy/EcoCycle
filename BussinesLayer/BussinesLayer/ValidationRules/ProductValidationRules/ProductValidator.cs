using DtoLayer.Dtos.ProductDto;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.ProductValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {

        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("The name field cannot be left empty!")
                .MaximumLength(30).WithMessage("Please enter a maximum of 30 characters!")
                .MinimumLength(2).WithMessage("Please enter a minimum of 2 characters!");

            RuleFor(x => x.ProductDescription)
                .MaximumLength(500).WithMessage("Please enter a maximum of 500 characters!")
                .MinimumLength(10).WithMessage("Please enter a minimum of 10 characters!");

            RuleFor(x => x.ProductWeigth)
                .NotEmpty().WithMessage("The product weigth field cannot be left empty!");

            RuleFor(x => x.ProductWeigthType)
                .NotEmpty().WithMessage("The product weigth type field cannot be left empty!");

            RuleFor(x => x.ProductPrice)
                .NotEmpty().WithMessage("The price field cannot be left empty!");

        }

    }
}
