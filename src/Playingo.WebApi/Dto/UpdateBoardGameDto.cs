using System;

namespace Playingo.WebApi.Dto
{
    public class UpdateBoardGameDto
    {
        public Guid BoardGameGuid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}