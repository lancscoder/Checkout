using MediatR;
using System;

namespace Api.Services.Requests
{
    public class DeleteItemRequest : IRequest
    {
        public Guid BasketId { get; set; }
        public Guid Id { get; set; }
    }
}
