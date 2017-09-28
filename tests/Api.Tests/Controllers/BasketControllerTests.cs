using Api.Controllers;
using Api.Models.Response;
using Api.Services.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Controllers
{
    public class BasketControllerTests
    {
        [Fact]
        public async Task Get_ShouldReturnOkResult_WhenBasketFound()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Basket>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Basket() { Id = expectedGuid }));

            var basketController = new BasketController(mediatr.Object);

            var actionResults = await basketController.Get(Guid.NewGuid());
            var okResult = actionResults as OkObjectResult;

            Assert.NotNull(okResult);

            var basket = okResult.Value as Basket;

            Assert.NotNull(basket);
            Assert.Equal(expectedGuid, basket.Id);
        }

        [Fact]
        public async Task Get_ShouldReturnNotFoundResult_WhenBasketNotFound()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Basket>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Basket>(null));

            var basketController = new BasketController(mediatr.Object);

            var actionResults = await basketController.Get(Guid.NewGuid());
            var notFoundResult = actionResults as NotFoundResult;

            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async Task Post_ShouldReturnANewBasket()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Basket>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Basket() { Id = expectedGuid }));

            var basketController = new BasketController(mediatr.Object);

            var actionResults = await basketController.Post();
            var createdResult = actionResults as CreatedAtActionResult;

            Assert.NotNull(createdResult);

            var basket = createdResult.Value as Basket;

            Assert.NotNull(basket);
            Assert.Equal(expectedGuid, basket.Id);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var basketController = new BasketController(mediatr.Object);

            var actionResults = await basketController.Delete(Guid.NewGuid());
            var noContentResult = actionResults as NoContentResult;

            Assert.NotNull(noContentResult);
        }
    }
}
