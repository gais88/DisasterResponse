using DisasterResponse.Application.Features.Aids.Commands.CreateAid;
using DisasterResponse.Application.Features.Aids.Queries.GetAidDetails;
using DisasterResponse.Application.Features.Aids.Queries.GetAidsList;
using DisasterResponse.Application.Features.Aids.ViewModels;
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
    public class AidController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AidController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllAids")]
        public async Task<ActionResult<List<AidVM>>> GetAllAids()
        {
            var dtos = await _mediator.Send(new GetAidListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetAidById")]
        public async Task<ActionResult<AidVM>> GetAidById(int id)
        {
            var getEventDetailQuery = new GetAidDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddAid")]
        public async Task<ActionResult<int>> AddAid([FromBody] CreateAidCommand createAidCommand)
        {
            int id = await _mediator.Send(createAidCommand);
            return Ok(id);
        }
    }
}
