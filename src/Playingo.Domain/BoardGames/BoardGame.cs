using System;

namespace Playingo.Domain.BoardGames
{
    public class BoardGame
    {
        public BoardGame(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationTime { get; set; }
    }
}