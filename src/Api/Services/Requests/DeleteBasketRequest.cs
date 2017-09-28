using MediatR;
using System;

namespace Api.Services.Requests
{
    public class DeleteBasketRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
