using Api.Controllers;
using Api.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests.Controllers
{
    public class ItemsControllerTests
    {
        [Fact]
        public async Task Get_ShouldReturnItems()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<IList<Item>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult((new List<Item>() { new Item(), new Item() }) as IList<Item>));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Get(Guid.NewGuid());
            var okResult = actionResults as OkObjectResult;

            Assert.NotNull(okResult);

            var items = okResult.Value as IList<Item>;

            Assert.NotNull(items);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public async Task Get_ShouldReturnOkResult_WhenItemFound()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Item()));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Get(Guid.NewGuid(), Guid.NewGuid());
            var okResult = actionResults as OkObjectResult;

            Assert.NotNull(okResult);

            var item = okResult.Value as Item;

            Assert.NotNull(item);
        }

        [Fact]
        public async Task Get_ShouldReturnNotFoundResult_WhenItemNotFound()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Item>(null));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Get(Guid.NewGuid(), Guid.NewGuid());
            var notFoundResult = actionResults as NotFoundResult;

            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async Task Post_ShouldReturnANewItem_WhenValidItemPassed()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Item() { Id = expectedGuid }));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Post(Guid.NewGuid(), new Models.Request.PostItem());
            var createdResult = actionResults as CreatedAtActionResult;

            Assert.NotNull(createdResult);

            var item = createdResult.Value as Item;

            Assert.NotNull(item);
            Assert.Equal(expectedGuid, item.Id);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenInvalidItemPassed()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Item>(null));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Post(Guid.NewGuid(), new Models.Request.PostItem());
            var badRequest = actionResults as BadRequestResult;

            Assert.NotNull(badRequest);
        }

        [Fact]
        public async Task Put_ShouldNoContent_WhenValidItemPassed()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Item() { Id = expectedGuid }));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Put(Guid.NewGuid(), Guid.NewGuid(), new Models.Request.PutItem());
            var noContentResult = actionResults as NoContentResult;

            Assert.NotNull(noContentResult);
        }

        [Fact]
        public async Task Put_ShouldReturnBadRequest_WhenInvalidItemPassed()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest<Item>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Item>(null));

            var itemController = new ItemsController(mediatr.Object);

            var actionResults = await itemController.Put(Guid.NewGuid(), Guid.NewGuid(), new Models.Request.PutItem());
            var badRequest = actionResults as BadRequestResult;

            Assert.NotNull(badRequest);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            var expectedGuid = Guid.NewGuid();

            var mediatr = new Mock<IMediator>();
            mediatr
                .Setup(m => m.Send(It.IsAny<IRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var itemsController = new ItemsController(mediatr.Object);

            var actionResults = await itemsController.Delete(Guid.NewGuid(), Guid.NewGuid());
            var noContentResult = actionResults as NoContentResult;

            Assert.NotNull(noContentResult);
        }
    }
}
