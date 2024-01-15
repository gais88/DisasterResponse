using DisasterResponse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        
        public DbSet<Donor> Donors { get; set; }   
        public DbSet<AffectedIndividual> AffectedIndividuals { get; set;}
        public DbSet<Aid> Aids { get; set;}
        public DbSet<IndividualRequest> IndividualRequests { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<DisbursesAid> DisbursesAids { get;set; }
        
    }
}
