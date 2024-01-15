using AutoMapper;
using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.Features.Donors.Commands.CreateDonor;
using DisasterResponse.Application.Profiles;
using DisasterResponse.Application.UnitTest.Common.Mocks.MockUOW;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DisasterResponse.Application.UnitTest.Common.Donors.Commands
{
    public class CreateDonorCommandTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateDonorCommandHandler _handler;

        public CreateDonorCommandTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            _mockUnitOfWork = MockUnitOfWork.GetUnitOfWork();
            _mapper = configurationProvider.CreateMapper();
            _handler = new CreateDonorCommandHandler(_mockUnitOfWork.Object,_mapper);

        }
        [Fact]
        public async Task CreateDonor_ValidData()
        {
            var _command = new CreateDonorCommand()
            {
                Name = "Test",
                Address = "sadadad",
                Email = "2323@dsd.com",
                Phone = "21205555"
            };

            await _handler.Handle(_command, CancellationToken.None);

            var allDonor = await _mockUnitOfWork.Object.Donor.ListAllAsync();

            allDonor.Count().ShouldBe(4);
        }
    }
}
