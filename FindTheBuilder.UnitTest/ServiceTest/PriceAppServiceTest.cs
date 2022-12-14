using FindTheBuilder.Applications.Services.PriceAppServices;
using FindTheBuilder.Applications.Services.PriceAppServices.DTO;
using Microsoft.Extensions.DependencyInjection;
using FindTheBuilder.Applications.Helper;
using Moq;
using FindTheBuilder.Databases.Models;

namespace FindTheBuilder.UnitTest.ServiceTest
{
    public class PriceAppServiceTest : IClassFixture<Startup>
    {
        private readonly ServiceProvider _serviceProvider;
        public PriceAppServiceTest(Startup fixtur)
        {
            _serviceProvider = fixtur.ServiceProvider;
        }

        [Fact]
        public void CreatePrice()
        {
            var service = _serviceProvider.GetService<IPriceAppService>();

            //Arrange
            PriceDTO price = new PriceDTO()
            {
                SkillId = 1,
                Product = "Your Mom",
                Size = 100,
                Price = 100000
            };

            //Act
            var result = service.Create(price);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdatePrice()
        {
            var service = _serviceProvider.GetService<IPriceAppService>();

            //Arrange
            UpdatePriceDTO price = new UpdatePriceDTO()
            {
                Id = 1,
                SkillId = 1,
                Product = "Your Mom is Gay",
                Size = 100,
                Price = 100000
            };

            //Act
            var result = service.Update(price);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DeletePrice()
        {
            var service = new Mock<IPriceAppService>();

            //Arrange
            string product = "Your Mom is Gay";
            Task<Prices> price = Task.Run(() => (new Prices() { Id = 1}));

            //Act
            var result = service.Setup(w => w.Delete(product)).Returns(price);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllPrices()
        {
            var service = _serviceProvider.GetService<IPriceAppService>();

            //Arrange
            PageInfo page = new PageInfo()
            {
                Page = 1,
                PageSize = 5
            };
            
            //Act
            var result = service.GetAllPrice(page);

            //Assert
            Assert.NotNull(result);
        }
    }
}
