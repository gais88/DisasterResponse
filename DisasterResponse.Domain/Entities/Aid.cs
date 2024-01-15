using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{
    public class Aid
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public AidType AidType { get; set; }
        public double Amount { get; set; }

        public int DonorId { get; set; }
        public Donor Donor { get; set; } = default!;

    }
}
