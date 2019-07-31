using System.Collections.Generic;

namespace Rental.Core.Entities
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<GameRental> GameRentals { get; set; }
    }
}