using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualList
{
    internal sealed class GetAffectedIndividualListQueryHandler : IRequestHandler<GetAffectedIndividualListQuery, List<AffectedIndividualListVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAffectedIndividualListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AffectedIndividualListVM>> Handle(GetAffectedIndividualListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.AffectedIndividual.ListAllAsync();
            return _mapper.Map<List<AffectedIndividualListVM>>(result);
        }
    }
}
