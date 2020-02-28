using AutoMapper;
using Playingo.Domain.Rentals;

namespace Rental.Core.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RentalWithDetails, RentalWithPaymentDetails>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => $"{src.Client.FirstName} {src.Client.LastName}"))
                .ForMember(dest => dest.BoardGameName, opt => opt.MapFrom(src => src.BoardGame.Name))
                .ForMember(dest => dest.ChargedDeposit, opt => opt.MapFrom(src => src.ChargedDeposit))
                .ForMember(dest => dest.RentalStartDateTime, opt => opt.MapFrom(src => src.CreationTime))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}