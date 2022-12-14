using FindTheBuilder.Applications.Services.TukangAppServices;
using FindTheBuilder.Applications.Services.TukangAppServices.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace FindTheBuilder.UnitTest.ServiceTest
{
    public class TukangAppServiceTest : IClassFixture<Startup>
    {
        private readonly ServiceProvider _serviceProvider;
        public TukangAppServiceTest(Startup fixtur)
        {
            _serviceProvider = fixtur.ServiceProvider;
        }

        [Fact]
        public void CreateTukang()
        {
            var service = _serviceProvider.GetService<ITukangAppService>();

            //Arrange
            TukangDTO tukang = new TukangDTO()
            {
                Name = "Test",
            };

            //Act
            var result = service.Create(tukang);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateTukang()
        {
            var service = _serviceProvider.GetService<ITukangAppService>();

            //Arrange
            UpdateTukangDTO update = new UpdateTukangDTO()
            {
                Id = 1,
                Name = "Tis"
            };

            //Act
            var result = service.Update(update);

            //Assert
            Assert.NotNull(result);
        }
    }
}
