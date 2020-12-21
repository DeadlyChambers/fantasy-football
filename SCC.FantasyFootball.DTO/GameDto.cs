using SCC.FantasyFootball.DTO.Interfaces;
using System;
using System.Collections.Generic;

namespace SCC.FantasyFootball.DTO
{
    public record GameDto : IEntityRecord
    {
        public int Id { get; set; }
        public int Hometeamid { get; set; }
        public int Awayteamid { get; set; }
        public DateTime Gamedate { get; set; }
        public short Homescore { get; set; }
        public short Awayscore { get; set; }

        //These should be the same during updates
        public TeamDto Awayteam { get; set; }
        public TeamDto Hometeam { get; set; }
        public IList<StatDto> Stats { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool IsDirty(object obj)
        {
            var original = (obj as GameDto); //Pushing db values into the object that was passed in from api
            var updated = this with { Stats = original.Stats, Createddate = original.Createddate, Modifieddate = original.Modifieddate, Awayteam = original.Awayteam, Hometeam = original.Hometeam };
            
            return original != updated;
        }
    }
}
