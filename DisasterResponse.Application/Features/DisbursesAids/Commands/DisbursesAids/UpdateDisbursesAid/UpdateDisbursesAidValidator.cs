using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids.UpdateDisbursesAid
{
    public class UpdateDisbursesAidValidator : AbstractValidator<UpdateDisbursesAidCommand>
    {
        public UpdateDisbursesAidValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(p => p.Id)
             .NotEmpty().WithMessage("{PropertyName} id is requeried")
             .NotNull();
             

            RuleFor(p => p.Desc)
              .NotEmpty().WithMessage("{PropertyName} desc is  requeried")
              .NotNull()
              .MaximumLength(250);
            
            RuleFor(p => p.DisbursesSteps).NotEmpty().IsInEnum()
                
                .MustAsync(async (value, s, cancelToken) =>
                {
                    if (value.DisbursesSteps == DisbursesSteps.Disburses)
                    {

                    var entity = await unitOfWork.DisbursesAid.GetByIdAsync(value.Id);
                    var result = await unitOfWork.Inventory.CheckInventoryLimit(entity.Amount, (InventoryType)entity.AidType);
                    return result;
                    }
                    return true;
                }) .WithMessage("{PropertyName} not Limit  in Inventory!, You can Ask Donors For Support");

        }
    }
}
