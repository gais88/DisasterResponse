using DisasterResponse.Application.Features.Aids.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Donors.ViewModels
{
    public class DonorDetailsVM:DonorListVM
    {
        public List<AidVM> Aids { get; set; } = default!;
    }
}
