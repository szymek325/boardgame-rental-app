using System;

namespace Rental.WebApi.Dto
{
    public class UpdateClientDto
    {
        public Guid ClientGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}