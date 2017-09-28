using Api.Services.Requests;
using Api.Stores;
using MediatR;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class DeleteBasketRequestHandler : IAsyncRequestHandler<DeleteBasketRequest>
    {
        private readonly IBasketStore _store;

        public DeleteBasketRequestHandler(IBasketStore store)
        {
            _store = store;
        }

        public Task Handle(DeleteBasketRequest request)
        {
            var domainBasket = _store.GetById(request.Id);

            if (domainBasket == null)
            {
                return Task.CompletedTask;
            }

            _store.Delete(request.Id);

            return Task.CompletedTask;
        }
    }
}
