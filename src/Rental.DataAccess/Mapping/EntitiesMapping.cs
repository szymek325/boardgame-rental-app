using AutoMapper;
using Rental.Core.Models.BoardGames;
using Rental.Core.Models.Clients;
using Rental.Core.Models.Rentals;

namespace Rental.DataAccess.Mapping
{
    internal class EntitiesMapping : Profile
    {
        public EntitiesMapping()
        {
            CreateMap<BoardGame, Entities.BoardGame>().ReverseMap();
            CreateMap<Client, Entities.Client>().ReverseMap();
            CreateMap<Core.Models.Rentals.Rental, Entities.Rental>().ReverseMap();
            CreateMap<RentalWithDetails, Entities.Rental>().ReverseMap();
        }
    }
}