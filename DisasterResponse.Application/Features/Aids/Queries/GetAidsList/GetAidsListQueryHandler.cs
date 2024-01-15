using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.Aids.ViewModels;
using MediatR;


namespace DisasterResponse.Application.Features.Aids.Queries.GetAidsList
{
    internal sealed class GetAidsListQueryHandler : IRequestHandler<GetAidListQuery, List<AidVM>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAidsListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AidVM>> Handle(GetAidListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Aid.ListAllAsync();
            return _mapper.Map<List<AidVM>>(result);
        }
    }
}
