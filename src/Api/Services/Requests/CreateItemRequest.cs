using Api.Models.Request;
using Api.Models.Response;
using MediatR;
using System;

namespace Api.Services.Requests
{
    public class CreateItemRequest : IRequest<Item>
    {
        public PostItem Item { get; set; }
        public Guid BasketId { get; set; }
    }
}
