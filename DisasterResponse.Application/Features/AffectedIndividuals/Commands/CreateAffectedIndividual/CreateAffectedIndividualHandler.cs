using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Commands.CreateAffectedIndividual
{
    internal sealed class CreateAffectedIndividualHandler : IRequestHandler<CreateAffectedIndividualCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAffectedIndividualHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAffectedIndividualCommand request, CancellationToken cancellationToken)
        {
           var validator = new CreateAffectedIndividualValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Count > 0)
            {
                throw new ValidationException(validatorResult);
            }
            var affectedIndividual = _mapper.Map<AffectedIndividual>(request);
            await _unitOfWork.AffectedIndividual.AddAsync(affectedIndividual);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new ServerErrorException("Server-Error");
            }

            return affectedIndividual.Id;
        }
    }
}
