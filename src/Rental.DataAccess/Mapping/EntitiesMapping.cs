using AutoMapper;
using Rental.Core.Models;

namespace Rental.DataAccess.Mapping
{
    internal class EntitiesMapping : Profile
    {
        public EntitiesMapping()
        {
            CreateMap<BoardGame, Entities.BoardGame>().ReverseMap();
            CreateMap<Client, Entities.Client>().ReverseMap();
            CreateMap<Core.Models.Rental, Entities.Rental>().ReverseMap();
            CreateMap<RentalWithDetails, Entities.Rental>().ReverseMap();
        }
    }
}