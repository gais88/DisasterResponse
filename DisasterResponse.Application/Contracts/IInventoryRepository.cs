using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IInventoryRepository : IGenericRepository<Inventory>
    {
        Task<bool> CheckInventoryLimit(double amount,InventoryType type);
        Task<double> GetInventoryTotalByType(InventoryType type);
    }
}
