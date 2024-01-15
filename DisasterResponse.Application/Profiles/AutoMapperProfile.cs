using AutoMapper;
using DisasterResponse.Application.CustomResolver;
using DisasterResponse.Application.Features.AffectedIndividuals.Commands.CreateAffectedIndividual;
using DisasterResponse.Application.Features.AffectedIndividuals.ViewModels;
using DisasterResponse.Application.Features.Aids.Commands.CreateAid;
using DisasterResponse.Application.Features.Aids.ViewModels;
using DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids;
using DisasterResponse.Application.Features.DisbursesAids.Commands.DisbursesAids.UpdateDisbursesAid;
using DisasterResponse.Application.Features.DisbursesAids.ViewModels;
using DisasterResponse.Application.Features.Donors.Commands.CreateDonor;
using DisasterResponse.Application.Features.Donors.ViewModels;
using DisasterResponse.Application.Features.IndividualRequests.Commands.CreateIndividualRequest;
using DisasterResponse.Application.Features.IndividualRequests.ViewModels;
using DisasterResponse.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Donor 
            CreateMap<Donor,DonorListVM>().ReverseMap();
            CreateMap<Donor, DonorDetailsVM>().ReverseMap();
            CreateMap<Donor, CreateDonorCommand>().ReverseMap();

            //Aid
            CreateMap<Aid, AidVM>()
                .ForMember(viewModel => viewModel.AidType, model => model.MapFrom(x => x.AidType))
                .ForMember(viewModel => viewModel.Donor, model => model.MapFrom(x => x.Donor))
                .ReverseMap();
            CreateMap<Aid, CreateAidCommand>()
               .ForMember(viewModel => viewModel.AidType, model => model.MapFrom(x => x.AidType))
               .ReverseMap();

            //AffectedIndividual
            CreateMap<AffectedIndividual, AffectedIndividualListVM>().ReverseMap();
            CreateMap<AffectedIndividual, AffectedIndividualDetailVM>()
                .ForMember(viewModel => viewModel.individualRequests, model => model.MapFrom(x => x.IndividualRequest))
                .ReverseMap();
            CreateMap<AffectedIndividual, CreateAffectedIndividualCommand>().ReverseMap();

            //IndividualRequest
            CreateMap<IndividualRequest, IndividualRequestListVM>()
                .ForMember(viewModel => viewModel.Priority, model => model.MapFrom(x => x.Priority))
                .ForMember(viewModel => viewModel.AffectedIndividual, model => model.MapFrom(x => x.AffectedIndividual.FullName))
                .ForMember(viewModel => viewModel.TotalAids, model => model.MapFrom<RequestAidsTotalResolver>())
                .ReverseMap();
            
            CreateMap<IndividualRequest, IndividualRequestDetailVM>()
                .ForMember(viewModel => viewModel.Priority, model => model.MapFrom(x => x.Priority))
                .ForMember(viewModel => viewModel.AffectedIndividual, model => model.MapFrom(x => x.AffectedIndividual))
                .ForMember(viewModel => viewModel.DisbursesAids, model => model.MapFrom(x => x.DisbursesAids))
                .ReverseMap();

            CreateMap<IndividualRequest, CreateIndividualRequestCommand>()
                .ForMember(viewModel => viewModel.Priority, model => model.MapFrom(x => x.Priority))
                .ReverseMap();

            //DisbursesAids
            CreateMap<DisbursesAid, DisbursesAidListVM>()
                .ForMember(viewModel => viewModel.AidType, model => model.MapFrom(x => x.AidType))
                .ReverseMap();
            CreateMap<DisbursesAid, DisbursesAidDetailVM>()
                .ForMember(viewModel => viewModel.AidType, model => model.MapFrom(x => x.AidType))
                .ReverseMap();

                 CreateMap<DisbursesAid, CreateDisbursesAidCommand>()
                .ForMember(viewModel => viewModel.AidType, model => model.MapFrom(x => x.AidType))
                .ReverseMap();
            CreateMap<DisbursesAid, UpdateDisbursesAidCommand>()
                .ForMember(viewModel => viewModel.DisbursesSteps, model => model.MapFrom(x => x.DisbursesSteps))
                .ReverseMap();
            
        }
    }
}
