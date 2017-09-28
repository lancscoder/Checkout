using Api.Models.Response;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using MediatR;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class GetBasketRequestHandler : IAsyncRequestHandler<GetBasketRequest, Basket>
    {
        private readonly IMapper _mapper;
        private readonly IBasketStore _store;

        public GetBasketRequestHandler(
            IMapper mapper,
            IBasketStore store)
        {
            _mapper = mapper;
            _store = store;
        }

        public Task<Basket> Handle(GetBasketRequest request)
        {
            var domainBasket = _store.GetById(request.Id);

            var basket = _mapper.Map<Basket>(domainBasket);

            return Task.FromResult(basket);
        }
    }
}
