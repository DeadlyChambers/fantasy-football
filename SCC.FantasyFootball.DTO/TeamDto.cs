using SCC.FantasyFootball.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCC.FantasyFootball.DTO
{
    public record TeamDto 
    {
        public int Teamid { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(TeamConferences))]
        public TeamConferences Conference { get; set; }
        [EnumDataType(typeof(TeamDivisions))]
        public TeamDivisions Division { get; set; }
        public string Location { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public IList<GameDto> GameAwayteams { get; set; }
        public IList<GameDto> GameHometeams { get; set; }
        public IList<StatDto> Stats { get; set; }
    }

    public static class TeamRecordExtensions
    {
        public static bool IsDirty(this TeamDto updatedDto, TeamDto originalDto)
        {
            return !updatedDto.Teamid.Equals(originalDto.Teamid) ||
                !updatedDto.Name.Equals(originalDto.Name) ||
                !updatedDto.Conference.Equals(originalDto.Conference) ||
                !updatedDto.Division.Equals(originalDto.Division) ||
                !updatedDto.Location.Equals(originalDto.Location);
        }
    }

}
