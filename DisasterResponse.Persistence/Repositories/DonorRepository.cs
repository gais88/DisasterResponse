using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.Repositories
{
    public class DonorRepository : GenericRepository<Donor>, IDonorRepository
    {
        

        public DonorRepository(AppDbContext appDbContext):base(appDbContext) { }

       

       
    }
}
