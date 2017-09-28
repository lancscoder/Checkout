using Api.Models.Response;
using MediatR;
using System;

namespace Api.Services.Requests
{
    public class GetBasketRequest : IRequest<Basket>
    {
        public Guid Id { get; set; }
    }
}
