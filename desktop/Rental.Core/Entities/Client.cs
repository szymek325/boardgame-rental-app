using System.Collections.Generic;

namespace Rental.Core.Entities
{
    public class Client : BaseEntity
    {
        public Client(string firstName, string lastName, string contactNumber, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Client()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}