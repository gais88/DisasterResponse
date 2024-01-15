using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{
    public class IndividualRequest
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public int AffectedIndividualId { get; set; }
        public virtual AffectedIndividual AffectedIndividual { get; set; } = default!;
        public virtual ICollection<DisbursesAid>? DisbursesAids { get; set; }


    }
}
