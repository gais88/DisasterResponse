using DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids;
using DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids.UpdateDisbursesAid;
using DisasterResponse.Application.Features.DisbursesAids.Queries.GetDisbursesAidDetails;
using DisasterResponse.Application.Features.DisbursesAids.Queries.GetDisbursesAidList;
using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Application.Features.Donors.Commands.CreateDonor;
using DisasterResponse.Application.Features.Donors.Queries.GetDonorDetails;
using DisasterResponse.Application.Features.Donors.Queries.GetDonorsList;
using DisasterResponse.Application.Features.Donors.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisbursesAidController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DisbursesAidController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllDisbursesAids")]
        public async Task<ActionResult<List<DisbursesAidListVM>>> GetAllDisbursesAids()
        {
            var dtos = await _mediator.Send(new GetDisbursesAidListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetDisbursesAidById")]
        public async Task<ActionResult<DisbursesAidDetailVM>> DisbursesAid(int id)
        {
            var getEventDetailQuery = new GetDisbursesAidDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddDisbursesAid")]
        public async Task<ActionResult<int>> Create([FromBody] CreateDisbursesAidCommand createDisbursesAidCommand)
        {
            int id = await _mediator.Send(createDisbursesAidCommand);
            return Ok(id);
        }
        [HttpPut(Name= "UpdateDisbursesAidState")]
        public async Task<ActionResult<DisbursesAidDetailVM>> UpdateDisbursesAidState(UpdateDisbursesAidCommand updateDisbursesAidCommand)
        {
            var result = await _mediator.Send(updateDisbursesAidCommand);

            return result;
        }
    }
}
