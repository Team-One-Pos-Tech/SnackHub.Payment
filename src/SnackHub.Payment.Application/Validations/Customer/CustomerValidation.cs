using FluentValidation;
using SnackHub.Payment.Application.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackHub.Payment.Application.Validations.Customer
{
    public class CustomerValidation : AbstractValidator<CustomerInput>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .NotNull().WithMessage("E-mail é obrigatório");
        }
    }
}
