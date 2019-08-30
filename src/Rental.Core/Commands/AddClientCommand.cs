using System;
using Rental.CQS;

namespace Rental.Core.Commands
{
    public class AddClientCommand : ICommand
    {
        public AddClientCommand(Guid newClientGuid, string firstName, string lastName, string contactNumber,
            string emailAddress)
        {
            NewClientGuid = newClientGuid;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid NewClientGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}