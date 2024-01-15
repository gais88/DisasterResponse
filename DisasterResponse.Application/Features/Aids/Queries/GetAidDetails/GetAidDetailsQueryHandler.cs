using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.Aids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Aids.Queries.GetAidDetails
{
    internal sealed class GetAidDetailsQueryHandler : IRequestHandler<GetAidDetailsQuery, AidVM>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAidDetailsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AidVM> Handle(GetAidDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Aid.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(Aid), request.Id);
            }

            return _mapper.Map<AidVM>(result);
        }
    }
}
