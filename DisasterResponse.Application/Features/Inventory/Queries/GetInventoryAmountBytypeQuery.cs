using DisasterResponse.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Inventory.Queries
{
    public class GetInventoryAmountBytypeQuery : IRequest<double>
    {
        public InventoryType InventoryType { get; set; }
    }
}
