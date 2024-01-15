using DisasterResponse.Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Donors.Commands.CreateDonor
{
    public class CreateDonorValidator: AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);

            RuleFor(p => p.Phone)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull();
        }
    }
       
    }
