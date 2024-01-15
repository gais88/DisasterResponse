using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.AffectedIndividuals.Commands.CreateAffectedIndividual;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Commands.CreateIndividualRequest
{
    internal sealed class CreateIndividualRequestCommandHandler : IRequestHandler<CreateIndividualRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIndividualRequestCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateIndividualRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIndividualRequestValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Count > 0)
            {
                throw new ValidationException(validatorResult);
            }
            var individualReques = _mapper.Map<IndividualRequest>(request);
            await _unitOfWork.IndividualRequest.AddAsync(individualReques);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new ServerErrorException("Server-Error");
            }

            return individualReques.Id;
        }
    }
}
