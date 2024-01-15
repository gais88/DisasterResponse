using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.IndividualRequests.ViewModels
{
    public class IndividualRequestListVM
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public string TotalAids { get; set; } = string.Empty;

        public string AffectedIndividual { get; set; } = string.Empty;

    }
}
