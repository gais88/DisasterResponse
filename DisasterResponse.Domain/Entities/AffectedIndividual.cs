using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{
    public class AffectedIndividual
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Age { get; set; }
        public virtual ICollection<IndividualRequest> IndividualRequest { get; set; } = default!;

    }
}
