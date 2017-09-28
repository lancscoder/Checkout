using System;

namespace Api.Models.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
