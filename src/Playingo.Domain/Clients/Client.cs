﻿using System;

namespace Playingo.Domain.Clients
{
    public class Client
    {
        public Client(Guid id, string firstName, string lastName, string contactNumber, string emailAddress)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            EmailAddress = emailAddress;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreationTime { get; set; }
    }
}