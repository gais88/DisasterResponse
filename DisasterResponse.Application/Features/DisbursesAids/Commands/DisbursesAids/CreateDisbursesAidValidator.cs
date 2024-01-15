using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids
{
    public class CreateDisbursesAidValidator : AbstractValidator<CreateDisbursesAidCommand>
    {
        public CreateDisbursesAidValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Desc)
              .NotEmpty()
              .NotNull()
              .MaximumLength(250);

            //RuleFor(p => p.Amount)
            //    .GreaterThan(0)
            //    .NotEmpty()
            //    .NotNull()
            //    .MustAsync(async (value,s, cancelToken) =>
            //                   {
            //                       var result = await unitOfWork.Inventory.CheckInventoryLimit(value.Amount,(InventoryType)value.AidType);
            //                       return result;
            //                   })
            //                      .WithMessage("{PropertyName} not Limit  in Inventory!");

            RuleFor(x => x.IndividualRequestId).NotEmpty()
                                  .MustAsync(async (value, cancelToken) =>
                                  {
                                      var result = await unitOfWork.IndividualRequest.IsValidIdAsync(value);
                                      return result;
                                  })
                                  .WithMessage("{PropertyName} Not Exist!");
        }
    }
}
