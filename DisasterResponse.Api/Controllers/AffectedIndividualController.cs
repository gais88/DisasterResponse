using DisasterResponse.Application.Features.AffectedIndividuals.Commands.CreateAffectedIndividual;
using DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualDetails;
using DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualList;
using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Application.Features.Aids.Commands.CreateAid;
using DisasterResponse.Application.Features.Aids.Queries.GetAidDetails;
using DisasterResponse.Application.Features.Aids.Queries.GetAidsList;
using DisasterResponse.Application.Features.Aids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterResponse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffectedIndividualController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AffectedIndividualController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet( Name = "GetAllAffectedIndividuals")]
        public async Task<ActionResult<List<AffectedIndividualListVM>>> GetAllAffectedIndividuals()
        {
            var dtos = await _mediator.Send(new GetAffectedIndividualListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetAffectedIndividualId")]
        public async Task<ActionResult<AffectedIndividualDetailVM>> AffectedIndividual(int id)
        {
            var getEventDetailQuery = new AffectedIndividualDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddAffectedIndividual")]
        public async Task<ActionResult<int>> AddAffectedIndividual([FromBody] CreateAffectedIndividualCommand CreateAffectedIndividualCommand)
        {
            int id = await _mediator.Send(CreateAffectedIndividualCommand);
            return Ok(id);
        }
    }
}
