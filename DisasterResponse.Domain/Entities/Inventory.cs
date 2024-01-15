using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public InventoryType InventoryType { get; set; }
    }
}
