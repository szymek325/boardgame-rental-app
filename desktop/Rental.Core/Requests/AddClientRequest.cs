using System;
using MediatR;

namespace Rental.Core.Requests
{
    public class AddClientRequest : IRequest<Guid>
    {
        public AddClientRequest(string firstName, string lastName, string contactNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}