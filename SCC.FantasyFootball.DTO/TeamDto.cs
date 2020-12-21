using SCC.FantasyFootball.Common.Enums;
using SCC.FantasyFootball.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCC.FantasyFootball.DTO
{
    public record TeamDto  : IEntityRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(TeamConferences))]
        public TeamConferences Conference { get; set; }
        [EnumDataType(typeof(TeamDivisions))]
        public TeamDivisions Division { get; set; }
        public string Location { get; set; }
        public IList<GameDto> GameAwayteams { get; set; }
        public IList<GameDto> GameHometeams { get; set; }
        public IList<StatDto> Stats { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool IsDirty(object obj)
        {
            var original = (obj as TeamDto);
            return !this.Id.Equals(original.Id) ||
                !this.Name.Equals(original.Name) ||
                !this.Conference.Equals(original.Conference) ||
                !this.Division.Equals(original.Division) ||
                !this.Location.Equals(original.Location);
        }
    }
}
