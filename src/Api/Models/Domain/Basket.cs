using System;
using System.Collections.Generic;

namespace Api.Models.Domain
{
    public class Basket
    {
        public Guid Id { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
