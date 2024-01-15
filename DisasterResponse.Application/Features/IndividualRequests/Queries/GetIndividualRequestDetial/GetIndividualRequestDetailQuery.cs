using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestDetial
{
    public class GetIndividualRequestDetailQuery : IRequest<IndividualRequestDetailVM>
    {
        public int Id { get; set; }
    }
}
