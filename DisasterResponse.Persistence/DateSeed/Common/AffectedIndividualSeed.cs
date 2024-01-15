using DisasterResponse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.DateSeed.Common
{
    public static class AffectedIndividualSeed
    {
        public static async Task SeedAffectedIndividualAsync(AppDbContext dbContext)
        {
            if (await dbContext.AffectedIndividuals.AnyAsync())
            {
                return;
            }

            var AffectedIndividuals = new List<AffectedIndividual>()
            {
                new AffectedIndividual()
                {
                    FullName = "Mohamad saab",
                    Phone = "009655454545",
                    Address= "turkey"
                },
                new AffectedIndividual()
                {
                    FullName = "Gohn Doo",
                    Phone = "09054545454",
                    Address= "Turkey"
                },

            };

            await dbContext.AddRangeAsync(AffectedIndividuals);
            await dbContext.SaveChangesAsync();
        }
    }
}
