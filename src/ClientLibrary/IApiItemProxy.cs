using System;
using System.Threading.Tasks;

namespace ClientLibrary
{
    internal interface IApiItemProxy
    {
        Task AddItem(Guid basketId, string description, int quantity);
        Task UpdateItem(Guid basketId, Guid id, int quantity);
        Task ClearItems(Guid basketId);
    }
}
