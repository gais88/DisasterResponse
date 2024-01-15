using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualList
{
    public class GetAffectedIndividualListQuery : IRequest<List<AffectedIndividualListVM>>
    {
    }
}
