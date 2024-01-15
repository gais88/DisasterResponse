

using DisasterResponse.Application.Features.Donors.ViewModels;

namespace DisasterResponse.Application.Features.Aids.ViewModels
{
    public class AidVM
    {
        public int Id { get; set; }
        public string Desc { get; set; } = string.Empty;
        public string AidType { get; set; } = string.Empty;
        public double Amount { get; set; }
        public DonorDetailsVM Donor { get; set; } = default!;
    }
}
