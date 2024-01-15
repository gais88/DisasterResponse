using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.Donors.ViewModels;
using MediatR;

namespace DisasterResponse.Application.Features.Donors.Queries.GetDonorsList
{
    internal sealed class GetDonorListQueryHandler : IRequestHandler<GetDonorListQuery, List<DonorListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetDonorListQueryHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }

        public async Task<List<DonorListVM>> Handle(GetDonorListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Donor.ListAllAsync();

            return _mapper.Map<List<DonorListVM>>(result);
        }
    }
}
