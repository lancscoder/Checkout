using MediatR;
using System;

namespace Api.Services.Requests
{
    public class DeleteItemsRequest : IRequest
    {
        public Guid BasketId { get; set; }
    }
}
