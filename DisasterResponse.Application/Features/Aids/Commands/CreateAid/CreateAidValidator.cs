using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Aids.Commands.CreateAid
{
    internal class CreateAidValidator : AbstractValidator<CreateAidCommand>
    {
        public CreateAidValidator(IUnitOfWork unitOfWork) {

            RuleFor(p => p.Desc)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(250);

            RuleFor(p => p.Amount)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.AidType).NotEmpty().IsInEnum();

            RuleFor(x => x.DonorId).NotEmpty()
                                   .MustAsync(async (value, cancelToken) =>
                                   {
                                       var result = await unitOfWork.Donor.IsValidIdAsync(value);
                                       return result;
                                   })
                                   .WithMessage("{PropertyName} Not Exist!");
        }
    }
}

