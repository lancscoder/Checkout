using Api.Services.Handlers;
using Api.Services.Requests;
using Api.Stores;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Services.Handlers
{
    public class DeleteBasketRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCallDelete_WhenValid()
        {
            var id = Guid.NewGuid();

            var store = new Mock<IBasketStore>();
            store
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(new Models.Domain.Basket());

            var handler = new DeleteBasketRequestHandler(store.Object);

            var request = new DeleteBasketRequest() { Id = id };
            await handler.Handle(request);

            store.Verify(v => v.Delete(id), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldNotCallDelete_WhenBasketDoesntExist()
        {
            var id = Guid.NewGuid();

            var store = new Mock<IBasketStore>();

            var handler = new DeleteBasketRequestHandler(store.Object);

            var request = new DeleteBasketRequest() { Id = Guid.NewGuid() };
            await handler.Handle(request);

            store.Verify(v => v.Delete(id), Times.Never);
        }
    }
}
