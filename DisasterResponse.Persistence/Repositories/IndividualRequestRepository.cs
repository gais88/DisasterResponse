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
    public class IndividualRequestRepository : GenericRepository<IndividualRequest>, IIndividualRequestRepository
    {
        public IndividualRequestRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IReadOnlyList<IndividualRequest>> ListAllAsync()
        {
            return await _dbContext.Set<IndividualRequest>().AsNoTracking()
                                                            .Include(x=>x.AffectedIndividual)
                                                            .Include(x=>x.DisbursesAids)
                                                            .ToListAsync();
        }
        public async Task<IndividualRequest> GetIndividualRequestWithAffectionById(int id)
        {
            var entity = await _dbContext.Set<IndividualRequest>().Include(x => x.AffectedIndividual)
                                                                  .Include(x=>x.DisbursesAids)
                                                                  .FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null) return null;
            return entity; 
                                                          
        }
    }
}
