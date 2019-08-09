using System;
using MediatR;

namespace Rental.Core.Interfaces.DataAccess.Client
{
    public class GetClientByIdRequest : IRequest<Models.Client>
    {
        public GetClientByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}