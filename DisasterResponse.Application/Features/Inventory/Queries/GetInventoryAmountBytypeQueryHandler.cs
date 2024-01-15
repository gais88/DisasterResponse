using DisasterResponse.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Inventory.Queries
{
    internal sealed class GetInventoryAmountBytypeQueryHandler : IRequestHandler<GetInventoryAmountBytypeQuery, double>
    {
        private readonly IUnitOfWork _unitOfWork;
public GetInventoryAmountBytypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<double> Handle(GetInventoryAmountBytypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Inventory.GetInventoryTotalByType(request.InventoryType);
            return result;
        }
    }
}
