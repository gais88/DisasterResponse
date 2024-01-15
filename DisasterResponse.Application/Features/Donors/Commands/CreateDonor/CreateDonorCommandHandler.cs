using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.Donors.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;


namespace DisasterResponse.Application.Features.Donors.Commands.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDonorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDonorValidator();
            var validationResult =  await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var donor = _mapper.Map<Donor>(request);

            await _unitOfWork.Donor.AddAsync(donor);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new ServerErrorException("Server-Error");
            }

            return donor.Id;
        }
    }
}
