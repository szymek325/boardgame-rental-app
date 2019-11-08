using System;

namespace Rental.React.Dto
{
    public class UpdateBoardGameDto
    {
        public Guid BoardGameGuid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}