using Api.Models.Response;
using MediatR;
using System;

namespace Api.Services.Requests
{
    public class GetItemRequest : IRequest<Item>
    {
        public Guid BasketId { get; set; }
        public Guid Id { get; set; }
    }
}
