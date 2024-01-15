using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IDonorRepository Donor { get; }
        IInventoryRepository Inventory { get; }
        IAffectedIndividualRepository AffectedIndividual { get; }
        IAidRepository Aid { get; }
        IIndividualRequestRepository IndividualRequest { get; }
        IDisbursesAidRepository DisbursesAid { get; }

        Task<bool> SaveAsync();
    }
}
