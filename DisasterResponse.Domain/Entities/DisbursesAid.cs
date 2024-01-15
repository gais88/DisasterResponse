using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{
    public class DisbursesAid
    {
        public int Id { get; set; }
        public string Desc { get; set; } =string.Empty;
        public double Amount { get; set; }
        public AidType AidType { get; set; }
        public DisbursesSteps DisbursesSteps { get; set; } = DisbursesSteps.Idle;
        public int IndividualRequestId { get; set; }

        public IndividualRequest IndividualRequest { get; set; } = default!;
    }
}
