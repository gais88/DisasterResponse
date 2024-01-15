using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.Repositories
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckInventoryLimit(double amount, InventoryType type)
        {

            // check if aid amount is avalible in inventory
            //var inventoryType = type == AidType.Financial ? InventoryType.Bank : InventoryType.Warehouse;
            var inventory = await _dbContext.Set<Inventory>().FirstOrDefaultAsync(x => x.InventoryType == type);
            if (inventory != null)
            {
                if (inventory.Amount - amount <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<double> GetInventoryTotalByType(InventoryType type)
        {
            var result = await _dbContext.Set<Inventory>().FirstOrDefaultAsync(x => x.InventoryType == type);
            return type == InventoryType.Bank ? result!.Amount : Math.Floor(result!.Amount); 
        }
    }
}
