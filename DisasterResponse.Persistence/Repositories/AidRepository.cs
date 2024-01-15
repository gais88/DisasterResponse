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
    public class AidRepository : GenericRepository<Aid>, IAidRepository
    {
        public AidRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IReadOnlyList<Aid>> ListAllAsync()
        {
            return await _dbContext.Set<Aid>().Include(x=>x.Donor).ToListAsync();
        }

        public async Task<bool> AddAidAndInventory(Aid aid)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {

                if (aid != null)
                {
                    await _dbContext.AddAsync(aid);
                    _dbContext.SaveChanges();
                    //increase  to inventory
                    var inventoryType = aid.AidType == AidType.Financial ? InventoryType.Bank : InventoryType.Warehouse;
                    var inventory = await _dbContext.Set<Inventory>().FirstOrDefaultAsync(x => x.InventoryType == inventoryType);
                    inventory.Amount += aid.Amount;
                     _dbContext.Update<Inventory>(inventory);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    
                return true;
                }
                return false;
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
