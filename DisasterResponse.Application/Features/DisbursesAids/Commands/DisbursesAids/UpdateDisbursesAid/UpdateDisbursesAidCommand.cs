using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Domain.Entities;
using DisasterResponse.Domain.Enums;
using MediatR;


namespace DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids.UpdateDisbursesAid
{
    public class UpdateDisbursesAidCommand :IRequest<DisbursesAidDetailVM>
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public DisbursesSteps DisbursesSteps { get; set; }
                             
    }
}
