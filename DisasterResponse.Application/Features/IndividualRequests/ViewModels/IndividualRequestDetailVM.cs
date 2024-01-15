using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.ViewModels
{
    public class IndividualRequestDetailVM : IndividualRequestListVM
    {
      
        public AffectedIndividualListVM AffectedIndividual { get; set; } = default!;
        public virtual ICollection<DisbursesAid>? DisbursesAids { get; set; }
    }
}
