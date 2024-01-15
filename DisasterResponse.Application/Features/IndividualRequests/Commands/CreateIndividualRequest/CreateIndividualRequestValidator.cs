using DisasterResponse.Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Commands.CreateIndividualRequest
{
    public class CreateIndividualRequestValidator : AbstractValidator<CreateIndividualRequestCommand>
    {
        public CreateIndividualRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x=>x.Desc).NotEmpty().NotNull();
            RuleFor(x=>x.Priority).NotEmpty().IsInEnum();
            RuleFor(x => x.AffectedIndividualId).NotEmpty()
                                  .MustAsync(async (value, cancelToken) =>
                                  {
                                      var result = await unitOfWork.AffectedIndividual.IsValidIdAsync(value);
                                      return result;
                                  })
                                  .WithMessage("{PropertyName} Not Exist!");
        }
    }
}
