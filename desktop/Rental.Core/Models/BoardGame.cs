using System;

namespace Rental.Core.Models
{
    public class BoardGame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime CreationTime { get; set; }
    }
}