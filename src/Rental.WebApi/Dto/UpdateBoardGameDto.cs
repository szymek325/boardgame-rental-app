using System;

namespace Rental.WebApi.Dto
{
    public class UpdateBoardGameDto
    {
        public Guid BoardGameGuid { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}