using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Enums
{
    public enum DisbursesSteps
    {
        Idle    = 1,
        Prepare =2,
        Disburses=3,
        Delivered = 4,
        Complete = 5,
    }
}
