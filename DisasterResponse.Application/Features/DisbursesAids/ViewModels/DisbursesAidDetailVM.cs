using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.ViewModels
{
    public class DisbursesAidDetailVM : DisbursesAidListVM
    {
        public IndividualRequest IndividualRequest { get; set; } = default!;
    }
}
