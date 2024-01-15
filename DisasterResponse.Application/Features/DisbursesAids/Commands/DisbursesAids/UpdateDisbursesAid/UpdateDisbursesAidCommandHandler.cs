using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids.UpdateDisbursesAid
{
    internal sealed class UpdateDisbursesAidCommandHandler : IRequestHandler<UpdateDisbursesAidCommand, DisbursesAidDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDisbursesAidCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DisbursesAidDetailVM> Handle(UpdateDisbursesAidCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDisbursesAidValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var result = await _unitOfWork.DisbursesAid.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(DisbursesAid), request.Id);
            }

            _mapper.Map(request, result, typeof(UpdateDisbursesAidCommand), typeof(DisbursesAid));
            if (!await _unitOfWork.DisbursesAid.UpdateDisburseAidStateAsync(result))
            {
                throw new ServerErrorException("Server-Error");

            }
            return _mapper.Map<DisbursesAidDetailVM>(result);
        }
    }
}
