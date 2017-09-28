using Api.Models.Response;
using Api.Services.Handlers;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Services.Handlers
{
    public class GetItemsRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnItems()
        {
            var mapper = new Mock<IMapper>();
            mapper
                .Setup(m => m.Map<IList<Item>>(It.IsAny<IList<Models.Domain.Item>>()))
                .Returns(new List<Item> { new Item { Id = Guid.NewGuid() } });

            var store = new Mock<IBasketStore>();

            var handler = new GetItemsRequestHandler(mapper.Object, store.Object);

            var items = await handler.Handle(new GetItemsRequest { BasketId = Guid.NewGuid() });

            Assert.Equal(1, items.Count);
        }
    }
}
