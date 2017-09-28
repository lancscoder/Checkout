using System;

namespace Api.Models.Response
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
