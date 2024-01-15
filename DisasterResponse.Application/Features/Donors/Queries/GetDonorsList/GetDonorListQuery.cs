using DisasterResponse.Application.Features.Donors.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Donors.Queries.GetDonorsList
{
    public  class GetDonorListQuery : IRequest<List<DonorListVM>>
    {

    }
}
