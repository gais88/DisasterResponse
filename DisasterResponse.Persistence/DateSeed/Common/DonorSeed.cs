using DisasterResponse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.DateSeed.Common
{
    public static class DonorSeed
    {
        public static async Task SeedDonorAsync(AppDbContext dbContext)
        {
            if (await dbContext.Donors.AnyAsync())
            {
                return;
            }

            var donors = new List<Donor>()
            {
                new Donor()
                {
                    Name = "GMS",
                    Email= "GMS@gmail.com",
                    Phone = "212-87566",
                    Address= "turkey"
                },
                new Donor()
                {
                    Name = "Global Fund",
                    Email= "Global@gmail.com",
                    Phone = "212-5876",
                    Address= "USA"
                },

            };

            await dbContext.AddRangeAsync(donors);
            await dbContext.SaveChangesAsync();
        }
    }
}

