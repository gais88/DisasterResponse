using DisasterResponse.Application.Contracts;
using DisasterResponse.Application.UnitTest.Common.Mocks.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.UnitTest.Common.Mocks.MockUOW
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUOfWork = new Mock<IUnitOfWork>();

            // Define Donor Mock Repository
            var mockDonorRepo = MockDonorRepository.GetMokBankRepository();

            

            // Setup donor Mock Repository for UnitOfWork
            mockUOfWork.Setup(x => x.Donor)
                       .Returns(mockDonorRepo.Object);

            

            // Setup SaveAsync for UnitOfWork
            mockUOfWork.Setup(x => x.SaveAsync()).ReturnsAsync(true);

            return mockUOfWork;
        }
    }
}
