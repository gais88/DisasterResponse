using DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualList;
using DisasterResponse.Application.Features.Donors.Commands.CreateDonor;
using DisasterResponse.Application.Features.Donors.Queries.GetDonorDetails;
using DisasterResponse.Application.Features.Donors.Queries.GetDonorsList;
using DisasterResponse.Application.Features.Donors.ViewModels;
using DisasterResponse.Application.Features.IndividualRequests.Commands.CreateIndividualRequest;
using DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestDetial;
using DisasterResponse.Application.Features.IndividualRequests.Queries.GetIndividualRequestList;
using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IndividualRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllIndividualRequest")]
        public async Task<ActionResult<List<IndividualRequestListVM>>> GetAllIndividualRequest()
        {
            var dtos = await _mediator.Send(new GetIndividualRequestListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetIndividualRequestById")]
        public async Task<ActionResult<IndividualRequestDetailVM>> IndividualRequest(int id)
        {
            var getEventDetailQuery = new GetIndividualRequestDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddIndividualRequest")]
        public async Task<ActionResult<int>> AddIndividualRequest([FromBody] CreateIndividualRequestCommand createIndividualRequestCommand)
        {
            int id = await _mediator.Send(createIndividualRequestCommand);
            return Ok(id);
        }
    }
}
