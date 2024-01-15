using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IDisbursesAidRepository : IGenericRepository<DisbursesAid>
    {
        Task<bool> UpdateDisburseAidStateAsync(DisbursesAid disbursesAid);
    }
}
