using AutoMapper;
using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.CustomResolver
{
    public class RequestAidsTotalResolver : IValueResolver<IndividualRequest, IndividualRequestListVM, string>
    {
        public string Resolve(IndividualRequest source, IndividualRequestListVM destination, string destMember, ResolutionContext context)
        {
            StringBuilder sb = new StringBuilder();
            if (source.DisbursesAids != null && source.DisbursesAids.Any())
            {
                var aidFinance = source.DisbursesAids.Where(x=>x.AidType == AidType.Financial).Sum(x => x.Amount);
                sb.Append($"Total Aid Finance {aidFinance.ToString("C")}");
                var aidInKind = source.DisbursesAids.Where(x=>x.AidType == AidType.Inkind).Sum(x => x.Amount);
                sb.Append($"- Total Aid Ink-Kind {Math.Floor(aidInKind)} boxs");
                return sb.ToString();
            }
            return "No Aids Disburses";
        }
    }
}
