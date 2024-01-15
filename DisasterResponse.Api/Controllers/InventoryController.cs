using DisasterResponse.Application.Features.Donors.Queries.GetDonorDetails;
using DisasterResponse.Application.Features.Donors.ViewModels;
using DisasterResponse.Application.Features.Inventory.Queries;
using DisasterResponse.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet("{type}", Name = "GetInventoryTotalByType")]
        public async Task<ActionResult<DonorDetailsVM>> GetInventoryTotalByType(InventoryType type)
        {
            var getEventDetailQuery = new GetInventoryAmountBytypeQuery() { InventoryType = type };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
    }
}
