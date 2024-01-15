using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestList
{
    public class GetIndividualRequestListQuery : IRequest<List<IndividualRequestListVM>>
    {
    }
}
