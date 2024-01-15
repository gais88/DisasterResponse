using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Queries.GetDisbursesAidList
{
    internal sealed class GetDisbursesAidDetailsQueryHandler : IRequestHandler<GetDisbursesAidDetailsQuery, DisbursesAidDetailVM>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetDisbursesAidDetailsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DisbursesAidDetailVM> Handle(GetDisbursesAidDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.DisbursesAid.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(DisbursesAid), request.Id);
            }
            return _mapper.Map<DisbursesAidDetailVM>(result);
        }
    }
}
