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
    public class GetBasketRequestHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnBasket()
        {
            var expectedId = Guid.NewGuid();

            var mapper = new Mock<IMapper>();
            mapper
                .Setup(m => m.Map<Basket>(It.IsAny<Models.Domain.Basket>()))
                .Returns(new Basket { Id = expectedId });

            var store = new Mock<IBasketStore>();

            var handler = new GetBasketRequestHandler(mapper.Object, store.Object);

            var basket = await handler.Handle(new GetBasketRequest { Id = Guid.NewGuid() });

            Assert.Equal(expectedId, basket.Id);
        }
    }
}
