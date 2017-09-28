using Api.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace Api.Services.Requests
{
    public class GetItemsRequest : IRequest<IList<Item>>
    {
        public Guid BasketId { get; set; }
    }
}
