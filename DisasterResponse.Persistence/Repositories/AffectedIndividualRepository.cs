using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.Repositories
{
    public class AffectedIndividualRepository : GenericRepository<AffectedIndividual>,IAffectedIndividualRepository
    {
        public AffectedIndividualRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<AffectedIndividual> GetByIdAsync(int id)
        {
            return await _dbContext.Set<AffectedIndividual>().Include(x => x.IndividualRequest)
                                                             .FirstOrDefaultAsync(x=>x.Id ==id);

        }
    }
}
