using System;
using System.Collections.Generic;

namespace Rental.Core.Models
{
    public class Client
    {
        public Client(string firstName, string lastName, string contactNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
            CreationTime = DateTime.UtcNow;
        }

        public Client()
        {
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreationTime { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}