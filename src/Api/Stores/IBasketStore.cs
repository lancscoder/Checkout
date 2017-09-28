using Api.Models.Domain;
using System;

namespace Api.Stores
{
    public interface IBasketStore
    {
        Basket GetById(Guid id);
        void Add(Basket basketToAdd);
        void Update(Basket basketToUpdate);
        void Delete(Guid id);
    }
}
