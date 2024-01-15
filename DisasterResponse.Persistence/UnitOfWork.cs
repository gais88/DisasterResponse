using DisasterResponse.Application.Contracts;
using DisasterResponse.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IDonorRepository Donor => new DonorRepository(_dbContext);
        public IInventoryRepository Inventory => new InventoryRepository(_dbContext);
        public IIndividualRequestRepository IndividualRequest => new IndividualRequestRepository(_dbContext);
        public IAffectedIndividualRepository AffectedIndividual => new AffectedIndividualRepository(_dbContext);
        public IAidRepository Aid => new AidRepository(_dbContext);
        public IDisbursesAidRepository DisbursesAid => new DisbursesAidRepository(_dbContext);


        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
