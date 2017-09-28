using Api.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Stores
{
    public class InMemoryBasketStore : IBasketStore
    {
        private static List<Basket> _baskets = new List<Basket>();

        public void Add(Basket basketToAdd)
        {
            _baskets.Add(basketToAdd);
        }

        public void Delete(Guid id)
        {
            _baskets.RemoveAll(b => b.Id == id);
        }

        public Basket GetById(Guid id)
        {
            return _baskets.FirstOrDefault(b => b.Id == id);
        }

        public void Update(Basket basketToUpdate)
        {
        }
    }
}
