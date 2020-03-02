using AutoMapper;
using Playingo.Domain.BoardGames;
using Playingo.Domain.Clients;
using Playingo.Domain.Rentals;

namespace Playingo.Infrastructure.Persistence.Mapping
{
    internal class EntitiesMapping : Profile
    {
        public EntitiesMapping()
        {
            CreateMap<BoardGame, Entities.BoardGame>().ReverseMap();
            CreateMap<Client, Entities.Client>().ReverseMap();
            CreateMap<Playingo.Domain.Rentals.Rental, Entities.Rental>().ReverseMap();
            CreateMap<RentalWithDetails, Entities.Rental>().ReverseMap();
        }
    }
}