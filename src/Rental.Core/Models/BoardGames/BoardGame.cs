using System;

namespace Rental.Core.Models.BoardGames
{
    public class BoardGame
    {
        public BoardGame(Guid id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime CreationTime { get; set; }
    }
}