using DisasterResponse.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Commands.CreateAffectedIndividual
{
    public class CreateAffectedIndividualValidator : AbstractValidator<CreateAffectedIndividualCommand>
    {
        public CreateAffectedIndividualValidator() {
            RuleFor(p => p.FullName)
                  .NotEmpty()
                  .NotNull()
                  .MaximumLength(100);

            RuleFor(p => p.Address)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.Phone)
                .NotEmpty()
                .NotNull(); 
            
            RuleFor(p => p.Age)
                .NotEmpty()
                .NotNull();

        }
    }
}
