using System;
using System.Threading.Tasks;

namespace ClientLibrary
{
    public interface IShoppingBasket
    {
        Task<Basket> Create();
        Task<Basket> Clear(Basket basket);
        Task<Basket> AddItem(Basket basket, string description, int quantity);
        Task<Basket> UpdateItem(Basket basket, Guid id, int quantity);
    }
}
