using DisasterResponse.Application.Features.Aids.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Aids.Queries.GetAidDetails
{
    public class GetAidDetailsQuery:IRequest<AidVM>
    {
        public int Id { get; set; }

    }
}
