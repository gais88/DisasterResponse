using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Domain.Entities;
using MediatR;
using System.Drawing;



namespace DisasterResponse.Application.Features.Aids.Commands.CreateAid
{
    internal sealed class CreateAidCommandHandler : IRequestHandler<CreateAidCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAidCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateAidCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAidValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            var aid = _mapper.Map<Aid>(request);

            if (!await _unitOfWork.Aid.AddAidAndInventory(aid))
            {
                throw new ServerErrorException("Server-Error");

            }

            return aid.Id;
        }

        
    }
}
