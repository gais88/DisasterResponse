using DisasterResponse.Application.Features.Aids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;


namespace DisasterResponse.Application.Features.Aids.Queries.GetAidsList
{
    public class GetAidListQuery : IRequest<List<AidVM>>
    {
    }
}
