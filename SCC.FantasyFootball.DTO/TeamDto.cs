using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.DTO
{
    public class TeamDto
    {
        public int Teamid { get; set; }
        public string Name { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public string Location { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }

        public IList<GameDto> GameAwayteams { get; set; }
        public IList<GameDto> GameHometeams { get; set; }
        public IList<StatDto> Stats { get; set; }
    }
}
