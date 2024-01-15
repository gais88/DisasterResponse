using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.AffectedIndividuals.Queries.GetAffectedIndividualDetails
{
    public class AffectedIndividualDetailQuery : IRequest<AffectedIndividualDetailVM>
    {
        public int Id { get; set; }
    }
}
