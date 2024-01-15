using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Exceptions;
using DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualList;
using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualDetails
{
    internal sealed class AffectedIndividualDetialQueryHandler : IRequestHandler<AffectedIndividualDetailQuery, AffectedIndividualDetailVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AffectedIndividualDetialQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AffectedIndividualDetailVM> Handle(AffectedIndividualDetailQuery request, CancellationToken cancellationToken)
        {
           var result = await _unitOfWork.AffectedIndividual.GetByIdAsync(request.Id);
            if (result == null)
            {
                throw new NotFoundException(nameof(AffectedIndividual), request.Id);
            }
            return _mapper.Map<AffectedIndividualDetailVM>(result);
        }
    }
}
