using Api.Models.Response;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class CreateItemRequestHandler : IAsyncRequestHandler<CreateItemRequest, Item>
    {
        private readonly IMapper _mapper;
        private readonly IBasketStore _store;

        public CreateItemRequestHandler(
            IMapper mapper,
            IBasketStore store)
        {
            _mapper = mapper;
            _store = store;
        }

        public Task<Item> Handle(CreateItemRequest request)
        {
            var domainBasket = _store.GetById(request.BasketId);

            if (domainBasket == null)
            {
                return Task.FromResult<Item>(null);
            }

            var domainItem = new Models.Domain.Item
            {
                Id = Guid.NewGuid(),
                Description = request.Item.Description,
                Quantity = request.Item.Quantity
            };

            domainBasket.Items.Add(domainItem);
            
            _store.Update(domainBasket);

            var item = _mapper.Map<Item>(domainItem);

            return Task.FromResult(item);
        }
    }
}
