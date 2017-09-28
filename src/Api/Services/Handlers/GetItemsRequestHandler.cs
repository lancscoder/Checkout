using Api.Models.Response;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class GetItemsRequestHandler : IAsyncRequestHandler<GetItemsRequest, IList<Item>>
    {
        private readonly IMapper _mapper;
        private readonly IBasketStore _store;

        public GetItemsRequestHandler(
            IMapper mapper,
            IBasketStore store)
        {
            _mapper = mapper;
            _store = store;
        }

        public Task<IList<Item>> Handle(GetItemsRequest request)
        {
            var domainBasket = _store.GetById(request.BasketId);

            var items = _mapper.Map<IList<Item>>(domainBasket?.Items);

            return Task.FromResult(items);
        }
    }
}
