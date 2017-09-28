using Api.Services.Requests;
using Api.Stores;
using MediatR;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class DeleteItemsRequestHandler : IAsyncRequestHandler<DeleteItemsRequest>
    {
        private readonly IBasketStore _store;

        public DeleteItemsRequestHandler(IBasketStore store)
        {
            _store = store;
        }

        public Task Handle(DeleteItemsRequest request)
        {
            var domainBasket = _store.GetById(request.BasketId);

            if (domainBasket == null)
            {
                return Task.CompletedTask;
            }

            domainBasket.Items?.Clear();

            _store.Update(domainBasket);

            return Task.CompletedTask;
        }
    }
}
