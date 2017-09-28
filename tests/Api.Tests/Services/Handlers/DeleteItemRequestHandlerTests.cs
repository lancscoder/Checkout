using Api.Services.Handlers;
using Api.Services.Requests;
using Api.Stores;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Services.Handlers
{
    public class DeleteItemRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCallUpdate_WhenValid()
        {
            var store = new Mock<IBasketStore>();
            store
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(new Models.Domain.Basket());

            var handler = new DeleteItemRequestHandler(store.Object);

            var request = new DeleteItemRequest() { BasketId = Guid.NewGuid() };
            await handler.Handle(request);

            store.Verify(v => v.Update(It.IsAny<Models.Domain.Basket>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldNotCallUpdate_WhenBasketDoesntExist()
        {
            var store = new Mock<IBasketStore>();

            var handler = new DeleteItemRequestHandler(store.Object);

            var request = new DeleteItemRequest() { BasketId = Guid.NewGuid() };
            await handler.Handle(request);

            store.Verify(v => v.Update(It.IsAny<Models.Domain.Basket>()), Times.Never);
        }
    }
}
