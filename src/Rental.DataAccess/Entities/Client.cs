using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rental.DataAccess.Entities
{
    internal class Client
    {
        [Key] [Required] public Guid Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string ContactNumber { get; set; }

        [Required] public string EmailAddress { get; set; }

        [Required] public DateTime CreationTime { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}