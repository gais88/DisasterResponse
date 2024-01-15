using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IIndividualRequestRepository : IGenericRepository<IndividualRequest>
    {
        Task<IndividualRequest> GetIndividualRequestWithAffectionById(int id);
    }
}
