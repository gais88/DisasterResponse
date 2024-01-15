using DisasterResponse.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.Commands.CreateIndividualRequest
{
    public class CreateIndividualRequestCommand : IRequest<int>
    {
        public string Desc { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public int AffectedIndividualId { get; set; }
    }
}
