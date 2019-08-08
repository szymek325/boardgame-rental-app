using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Requests.Handlers
{
    public class GetClientByIdRequest : IRequest<Client>
    {
        public GetClientByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}