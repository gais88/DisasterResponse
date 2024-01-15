using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.ViewModels
{
    public class AffectedIndividualDetailVM:AffectedIndividualListVM
    {
        public List<IndividualRequestListVM> individualRequests { get; set; } = default!;
    }
}
