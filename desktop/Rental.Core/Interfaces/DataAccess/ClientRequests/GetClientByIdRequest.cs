using System;
using MediatR;
using Rental.Core.Models;

namespace Rental.Core.Interfaces.DataAccess.ClientRequests
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