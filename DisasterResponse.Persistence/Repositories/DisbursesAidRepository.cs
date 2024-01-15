using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.Repositories
{
    public class DisbursesAidRepository : GenericRepository<DisbursesAid>, IDisbursesAidRepository
    {
        public DisbursesAidRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async override Task<DisbursesAid> GetByIdAsync(int id)
        {
            return await _dbContext.Set<DisbursesAid>().Include(x => x.IndividualRequest).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> UpdateDisburseAidStateAsync(DisbursesAid disbursesAid)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {

                if (disbursesAid != null)
                {
                     _dbContext.Update(disbursesAid);
                    _dbContext.SaveChanges();
                    // check if aid amount is avalible in inventory
                    if (disbursesAid.DisbursesSteps == DisbursesSteps.Disburses)
                    {

                    var inventoryType = disbursesAid.AidType == AidType.Financial ? InventoryType.Bank : InventoryType.Warehouse;
                    var inventory = await _dbContext.Set<Inventory>().FirstOrDefaultAsync(x => x.InventoryType == inventoryType);
                      // decrease amount from inventory
                      if (inventory is null)
                      {
                        throw new Exception();
                      }
                      inventory.Amount -= disbursesAid.Amount;
                      _dbContext.Update<Inventory>(inventory);
                      _dbContext.SaveChanges();
                    }
                    }
                   
                    transaction.Commit();

                    return true;
                
                
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}
