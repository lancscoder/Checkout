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
    public class UpdateItemRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnItem_WhenValid()
        {
            var itemId = Guid.NewGuid();

            var mapper = new Mock<IMapper>();
            mapper
                .Setup(m => m.Map<Item>(It.IsAny<Models.Domain.Item>()))
                .Returns(new Item { Id = Guid.NewGuid() });

            var store = new Mock<IBasketStore>();
            store
                .Setup(s => s.GetById(It.IsAny<Guid>()))
                .Returns(new Models.Domain.Basket
                {
                    Items = new List<Models.Domain.Item>
                    {
                        new Models.Domain.Item
                        {
                            Id = itemId
                        }
                    }
                });

            var handler = new UpdateItemRequestHandler(mapper.Object, store.Object);

            var item = await handler.Handle(new UpdateItemRequest { BasketId = Guid.NewGuid(), Id = itemId, Item  = new Models.Request.PutItem() });

            store.Verify(v => v.Update(It.IsAny<Models.Domain.Basket>()), Times.Once);
            Assert.NotNull(item);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenItemNotValid()
        {
            var itemId = Guid.NewGuid();

            var mapper = new Mock<IMapper>();
            var store = new Mock<IBasketStore>();

            var handler = new UpdateItemRequestHandler(mapper.Object, store.Object);

            var item = await handler.Handle(new UpdateItemRequest { BasketId = Guid.NewGuid(), Id = itemId, Item = new Models.Request.PutItem() });

            store.Verify(v => v.Update(It.IsAny<Models.Domain.Basket>()), Times.Never);
            Assert.Null(item);
        }
    }
}
