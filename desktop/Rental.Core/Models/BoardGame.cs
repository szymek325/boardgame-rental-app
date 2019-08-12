using System;

namespace Rental.Core.Models
{
    public class BoardGame
    {
        public BoardGame(string name, float price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            CreationTime = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime CreationTime { get; set; }
    }
}