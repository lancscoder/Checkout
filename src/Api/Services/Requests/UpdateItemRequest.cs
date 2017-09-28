using Api.Models.Request;
using Api.Models.Response;
using MediatR;
using System;

namespace Api.Services.Requests
{
    public class UpdateItemRequest : IRequest<Item>
    {
        public PutItem Item { get; set; }
        public Guid BasketId { get; set; }
        public Guid Id { get; set; }
    }
}
