using System;
using MediatR;

namespace Rental.Core.Requests.Clients
{
    public class AddClientRequest : IRequest<AddRequestResult>
    {
        public AddClientRequest(Guid clientGuid, string firstName, string lastName, string contactNumber,
            string emailAddress)
        {
            ClientGuid = clientGuid;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid ClientGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}