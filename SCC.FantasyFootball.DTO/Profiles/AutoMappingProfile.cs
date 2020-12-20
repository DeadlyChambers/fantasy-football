using AutoMapper;
using SCC.FantasyFootball.Common.Enums;
using SCC.FantasyFootball.Common.Extensions;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.DTO.Profiles
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            //DTOs to Entity
            CreateMap<TeamDto, Team>().ForMember(dest => dest.Conference, opt => opt.MapFrom(src => src.Conference.GetId()))
                .ForMember(dest => dest.Division, opt => opt.MapFrom(src => src.Division.GetId())); 
            CreateMap<GameDto, Game>();
            CreateMap<PlayerDto, Player>().ForMember(dest => dest.Positions, opt => opt.MapFrom(src => src.Positions.GetId()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetId()))
                //I don't feel this game status should live directly on the player. It seems to specific and doesn't offer snapshotting
                .ForMember(dest => dest.PlayingStatus, opt => opt.MapFrom(src => src.Status.GetId()));
            CreateMap<Game, GameDto>();
            CreateMap<StatDto, Stat>();

            //Entity to DTOs
            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Conference, opt => opt.MapFrom(src => src.Conference.MappedToEnum<TeamConferences>()))
                .ForMember(dest => dest.Division, opt => opt.MapFrom(src => src.Division.MappedToEnum<TeamDivisions>()));

            CreateMap<Player, PlayerDto>()
                //Need to do something about the position array property, possibly implement some sort of multiple select list and project to an array
                .ForMember(dest => dest.Positions, opt => opt.MapFrom(src => src.Positions[0].MappedToEnum<PlayerPosition>())) 
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.MappedToEnum<PlayerStatus>()))
                //I don't feel this game status should live directly on the player. It seems to specific and doesn't offer snapshotting
                .ForMember(dest => dest.PlayingStatus, opt => opt.MapFrom(src => src.Status.MappedToEnum<PlayerGameStatus>()));
            CreateMap<Game, GameDto>();
            CreateMap<Stat, StatDto>();
        }
    }
}
