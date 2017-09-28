using System;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly IApiBasketProxy _apiBasketProxy;
        private readonly IApiItemProxy _apiItemProxy;

        public ShoppingBasket()
        {
            _apiBasketProxy = new ApiBasketProxy();
            _apiItemProxy = new ApiItemProxy();
        }

        public async Task<Basket> Create()
        {
            return await _apiBasketProxy.CreateBasket();
        }

        public async Task<Basket> Clear(Basket basket)
        {
            await _apiItemProxy.ClearItems(basket.Id);

            return await _apiBasketProxy.GetBasket(basket.Id);
        }

        public async Task<Basket> AddItem(Basket basket, string description, int quantity = 1)
        {
            await _apiItemProxy.AddItem(basket.Id, description, quantity);

            return await _apiBasketProxy.GetBasket(basket.Id);
        }

        public async Task<Basket> UpdateItem(Basket basket, Guid id, int quantity)
        {
            await _apiItemProxy.UpdateItem(basket.Id, id, quantity);

            return await _apiBasketProxy.GetBasket(basket.Id);
        }
    }
}
