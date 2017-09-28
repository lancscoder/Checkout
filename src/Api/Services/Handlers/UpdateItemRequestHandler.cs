using Api.Models.Response;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class UpdateItemRequestHandler : IAsyncRequestHandler<UpdateItemRequest, Item>
    {
        private readonly IMapper _mapper;
        private readonly IBasketStore _store;

        public UpdateItemRequestHandler(
            IMapper mapper,
            IBasketStore store)
        {
            _mapper = mapper;
            _store = store;
        }

        public Task<Item> Handle(UpdateItemRequest request)
        {
            var domainBasket = _store.GetById(request.BasketId);
            var domainItem = domainBasket?.Items?.FirstOrDefault(i => i.Id == request.Id);

            if (domainItem == null)
            {
                return Task.FromResult<Item>(null);
            }

            domainItem.Quantity = request.Item.Quantity;

            _store.Update(domainBasket);

            var item = _mapper.Map<Item>(domainItem);

            return Task.FromResult(item);
        }
    }
}
