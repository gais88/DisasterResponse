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
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllDonors")]
        public async Task<ActionResult<List<DonorListVM>>> GetAllDonors()
        {
            var dtos = await _mediator.Send(new GetDonorListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetDonorById")]
        public async Task<ActionResult<DonorDetailsVM>> GetDonorById(int id)
        {
            var getEventDetailQuery = new GetDonorDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddDonor")]
        public async Task<ActionResult<int>> AddDonor([FromBody] CreateDonorCommand createDonorCommand)
        {
            int id = await _mediator.Send(createDonorCommand);
            return Ok(id);
        }

    }
}
