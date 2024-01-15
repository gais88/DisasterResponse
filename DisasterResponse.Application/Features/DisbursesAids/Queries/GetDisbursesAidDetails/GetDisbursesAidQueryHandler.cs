using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Queries.GetDisbursesAidDetails
{
    internal sealed class GetDisbursesAidQueryHandler : IRequestHandler<GetDisbursesAidListQuery, List<DisbursesAidListVM>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetDisbursesAidQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DisbursesAidListVM>> Handle(GetDisbursesAidListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.DisbursesAid.ListAllAsync();
            return _mapper.Map<List<DisbursesAidListVM>>(result);
        }
    }
}
