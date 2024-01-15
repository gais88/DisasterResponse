using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.Donors.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Donors.Queries.GetDonorDetails
{
    internal sealed class GetDonorDetailsQueryHandler : IRequestHandler<GetDonorDetailsQuery, DonorDetailsVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDonorDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DonorDetailsVM> Handle(GetDonorDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Donor.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(Donor), request.Id);
            }
            return _mapper.Map<DonorDetailsVM>(result);    
        }
    }
}
