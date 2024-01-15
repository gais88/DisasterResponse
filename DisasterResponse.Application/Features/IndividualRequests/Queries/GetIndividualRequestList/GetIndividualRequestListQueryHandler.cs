using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestList
{
    internal sealed class GetIndividualRequestListQueryHandler : IRequestHandler<GetIndividualRequestListQuery, List<IndividualRequestListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetIndividualRequestListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<IndividualRequestListVM>> Handle(GetIndividualRequestListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.IndividualRequest.ListAllAsync();
            return _mapper.Map<List<IndividualRequestListVM>>(result);  
        }
    }
}
