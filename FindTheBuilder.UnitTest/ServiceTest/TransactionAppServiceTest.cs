using FindTheBuilder.Applications.Services.TransactionAppServices;
using FindTheBuilder.Applications.Services.TransactionAppServices.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace FindTheBuilder.UnitTest.ServiceTest
{
    public class TransactionAppServiceTest : IClassFixture<Startup>
    {
        private readonly ServiceProvider _serviceProvider;
        public TransactionAppServiceTest(Startup fixtur)
        {
            _serviceProvider = fixtur.ServiceProvider;
        }

        [Fact]
        public void Create()
        {
            var service = _serviceProvider.GetService<ITransactionAppService>();

            //Arrange
            TransactionDTO trans = new TransactionDTO()
            {
                CustomerName = "Agus Ketoprak",
                PriceId = 1
            };

            //Act
            var result = service.Create(trans);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Update()
        {
            //Arrange
            var service = new Mock<ITransactionAppService>();

            UpdateTransactionDTO trans = new UpdateTransactionDTO()
            {
                Id = 1,

                PriceId = 1
            };

            //Act
            var result = service.Setup(w => w.Update(trans));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdatePayment()
        {
            var service = _serviceProvider.GetService<ITransactionAppService>();

            //Arrange
            int id = 1;

            //Act
            var result = service.UpdatePayment(id);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetActiveTransactionByName()
        {
            var service = _serviceProvider.GetService<ITransactionAppService>();

            //Arrange
            int id = 1;

            //Act
            var result = service.GetTransActiveById(id);

            //Assert
            Assert.NotNull(result);
        }
    }
}
