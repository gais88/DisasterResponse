using DisasterResponse.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.Aids.Commands.CreateAid
{
    public class CreateAidCommand:IRequest<int>
    {
        public string Desc { get; set; } = string.Empty;
        public AidType AidType { get; set; }
        public double Amount { get; set; }
        public int DonorId { get; set; }
    }
}
