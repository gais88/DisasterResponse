using DisasterResponse.Application.Contracts;
using DisasterResponse.Domain.Entities;

using Moq;
using System.Drawing;


namespace DisasterResponse.Application.UnitTest.Common.Mocks.Common
{
    public static class MockDonorRepository
    {
        public static Mock<IDonorRepository> GetMokBankRepository()
        {
            var donors = new List<Donor>()
        {
            new Donor()
            {
                Id = 1,
                Address = "Turkey - Istanmbul",
                Email = "sdsds@Dsds.com",
                Phone = "212-854556",
                Name = "GBS"
            }
            ,new Donor()
            {
                Id = 2,
                Address = "Gemany - Berline",
                Email = "sdsds@Dsds.com",
                Phone = "212-854556",
                Name = "CMS"
            }
            ,new Donor()
            {
                Id = 3,
                Address = "USA - DC",
                Email = "sdsds@Dsds.com",
                Phone = "212-854556",
                Name = "DC"
            },
           
        };

            var mockRepository = new Mock<IDonorRepository>();

            mockRepository.Setup(x => x.AddAsync(It.IsAny<Donor>()))
                          .ReturnsAsync((Donor donor) =>
                          {
                              donors.Add(donor);
                              return donor;
                          });

            mockRepository.Setup(x => x.ListAllAsync())
                          .ReturnsAsync(donors);

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                          .ReturnsAsync((int id) => donors.FirstOrDefault(x => x.Id == id));

            return mockRepository;
        }
    }
}
