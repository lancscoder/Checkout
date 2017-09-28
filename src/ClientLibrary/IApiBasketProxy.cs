using System;
using System.Threading.Tasks;

namespace ClientLibrary
{
    internal interface IApiBasketProxy
    {
        Task<Basket> GetBasket(Guid id);
        Task<Basket> CreateBasket();
    }
}
