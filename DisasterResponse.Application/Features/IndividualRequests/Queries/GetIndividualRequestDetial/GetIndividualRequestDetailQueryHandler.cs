using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestDetial
{
    internal sealed class GetIndividualRequestDetailQueryHandler : IRequestHandler<GetIndividualRequestDetailQuery, IndividualRequestDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetIndividualRequestDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IndividualRequestDetailVM> Handle(GetIndividualRequestDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.IndividualRequest.GetIndividualRequestWithAffectionById(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(IndividualRequests), request.Id);
            }
            return _mapper.Map<IndividualRequestDetailVM>(result); 
        }
    }
}
