using Api.Services.Requests;
using Api.Stores;
using MediatR;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class DeleteItemRequestHandler : IAsyncRequestHandler<DeleteItemRequest>
    {
        private readonly IBasketStore _store;

        public DeleteItemRequestHandler(IBasketStore store)
        {
            _store = store;
        }

        public Task Handle(DeleteItemRequest request)
        {
            var domainBasket = _store.GetById(request.BasketId);

            if (domainBasket == null)
            {
                return Task.CompletedTask;
            }

            var domainItem = domainBasket.Items?.RemoveAll(i => i.Id == request.Id);

            _store.Update(domainBasket);

            return Task.CompletedTask;
        }
    }
}
