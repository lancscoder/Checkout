using Api.Models.Response;
using Api.Services.Handlers;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Services.Handlers
{
    public class CreateItemRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnItem_WhenValid()
        {
            var expectedId = Guid.NewGuid();

            var mapper = new Mock<IMapper>();
            mapper
                .Setup(m => m.Map<Item>(It.IsAny<Models.Domain.Item>()))
                .Returns(new Item { Id = expectedId });

            var store = new Mock<IBasketStore>();
            store
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(new Models.Domain.Basket());
            
            var handler = new CreateItemRequestHandler(mapper.Object, store.Object);

            var request = new CreateItemRequest() { BasketId = Guid.NewGuid(), Item = new Models.Request.PostItem() };
            var item = await handler.Handle(request);

            Assert.Equal(expectedId, item.Id);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenBasketDoesntExist()
        {
            var mapper = new Mock<IMapper>();
            var store = new Mock<IBasketStore>();

            var handler = new CreateItemRequestHandler(mapper.Object, store.Object);

            var request = new CreateItemRequest() { BasketId = Guid.NewGuid() };
            var item = await handler.Handle(request);

            Assert.Null(item);
        }
    }
}
