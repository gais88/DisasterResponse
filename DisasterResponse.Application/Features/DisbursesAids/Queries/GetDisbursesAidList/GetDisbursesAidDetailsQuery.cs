﻿using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Features.DisbursesAids.Queries.GetDisbursesAidList
{
    public class GetDisbursesAidDetailsQuery:IRequest<DisbursesAidDetailVM>
    {
        public int Id { get; set; }
    }
}
