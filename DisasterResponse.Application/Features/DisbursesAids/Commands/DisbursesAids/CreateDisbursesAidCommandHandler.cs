using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Domain.Entities;
using MediatR;
using System.Security.Cryptography;


namespace DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids
{
    internal sealed class CreateDisbursesAidCommandHandler : IRequestHandler<CreateDisbursesAidCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDisbursesAidCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDisbursesAidCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDisbursesAidValidator(_unitOfWork);
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (validatorResult.Errors.Count > 0)
            {
                throw new ValidationException(validatorResult);
            }
            var disburseAid = _mapper.Map<DisbursesAid>(request);
            await _unitOfWork.DisbursesAid.AddAsync(disburseAid);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new ServerErrorException("Server-Error");
            }
            //if (!await _unitOfWork.DisbursesAid.AddDisburseAidAndUpdateInventoryAsync(disburseAid))
            //{
            //    throw new ServerErrorException("Server-Error");

            //}
            return disburseAid.Id;
        }
    }
}
