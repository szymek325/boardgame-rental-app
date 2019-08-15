using System;
using MediatR;
using Rental.Common;

namespace Rental.Core.Commands
{
    public class UpdateClientCommand : ICommand
    {
        public UpdateClientCommand(Guid id, string firstName, string lastName, string contactNumber,
            string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string ContactNumber { get; }
        public string EmailAddress { get; }
    }
}