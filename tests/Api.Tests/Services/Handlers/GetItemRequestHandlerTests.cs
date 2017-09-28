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
    public class GetItemRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnItem()
        {
            var expectedId = Guid.NewGuid();

            var mapper = new Mock<IMapper>();
            mapper
                .Setup(m => m.Map<Item>(It.IsAny<Models.Domain.Item>()))
                .Returns(new Item { Id = expectedId });

            var store = new Mock<IBasketStore>();

            var handler = new GetItemRequestHandler(mapper.Object, store.Object);

            var item = await handler.Handle(new GetItemRequest { BasketId = Guid.NewGuid(), Id = Guid.NewGuid() });

            Assert.Equal(expectedId, item.Id);
        }
    }
}
