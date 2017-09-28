using Api.Models.Response;
using Api.Services.Requests;
using Api.Stores;
using AutoMapper;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Api.Services.Handlers
{
    public class CreateBasketRequestHandler : IAsyncRequestHandler<CreateBasketRequest, Basket>
    {
        private readonly IMapper _mapper;
        private readonly IBasketStore _store;

        public CreateBasketRequestHandler(
            IMapper mapper,
            IBasketStore store)
        {
            _mapper = mapper;
            _store = store;
        }

        public Task<Basket> Handle(CreateBasketRequest request)
        {
            var domainBasket = new Models.Domain.Basket
            {
                Id = Guid.NewGuid()
            };

             _store.Add(domainBasket);

            var basket = _mapper.Map<Basket>(domainBasket);

            return Task.FromResult(basket);
        }
    }
}
