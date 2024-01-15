using DisasterResponse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.DateSeed.Common
{
    public static class InventorySeed
    {

    public static async Task SeedInventoryAsync(AppDbContext dbContext)
    {
        if (await dbContext.Inventory.AnyAsync())
        {
            return;
        }

            var inventories = new List<Inventory>()
            {
                new Inventory()
                {
                    InventoryType = Domain.Enums.InventoryType.Bank,
                    Amount = 0,
                },
                 new Inventory()
                {
                    InventoryType = Domain.Enums.InventoryType.Warehouse,
                    Amount = 0
                },

            };

        await dbContext.AddRangeAsync(inventories);
        await dbContext.SaveChangesAsync();
    }
}
    }
