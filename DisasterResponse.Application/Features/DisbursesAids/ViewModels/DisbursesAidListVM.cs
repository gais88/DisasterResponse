using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.ViewModels
{
    public class DisbursesAidListVM
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public AidType AidType { get; set; }
        public double Amount { get; set; }
        public DisbursesSteps DisbursesSteps { get; set; }
    }
}
