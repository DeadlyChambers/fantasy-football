using AutoMapper;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.DTO.Profiles
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<TeamDto, Team>();
            CreateMap<GameDto, Game>();
            CreateMap<PlayerDto, Player>();
            CreateMap<StatDto, Stat>();
        }
    }
}
