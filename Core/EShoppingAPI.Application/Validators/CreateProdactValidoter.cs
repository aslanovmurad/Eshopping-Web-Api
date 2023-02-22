using EShoppingAPI.Application.ViewModles.Product;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Validators
{
    public class CreateProdactValidoter : AbstractValidator<VM_Create_Product>
    {
        public CreateProdactValidoter()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("plese  write name")
                .MaximumLength(150)
                .MinimumLength(3)
                    .WithMessage("please 3-150 caracter");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("please write stock")
                .Must(s => s >= 0)
                    .WithMessage("stock not -");

            RuleFor(p => p.Price)
               .NotEmpty()
               .NotNull()
                   .WithMessage("please write stock")
               .Must(s => s >= 0)
                   .WithMessage("stock not -");
        }
    }
}
