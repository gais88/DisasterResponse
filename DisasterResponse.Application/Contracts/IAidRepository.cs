using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IAidRepository : IGenericRepository<Aid>
    {
        public  Task<bool> AddAidAndInventory(Aid aid);
    }
}
