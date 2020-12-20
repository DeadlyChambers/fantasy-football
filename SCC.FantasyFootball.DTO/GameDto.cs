using System;
using System.Collections.Generic;

namespace SCC.FantasyFootball.DTO
{
    public class GameDto
    {
        public int Gameid { get; set; }
        public int Hometeamid { get; set; }
        public int Awayteamid { get; set; }
        public DateTime Gamedate { get; set; }
        public short Homescore { get; set; }
        public short Awayscore { get; set; }

        public TeamDto Awayteam { get; set; }
        public TeamDto Hometeam { get; set; }
        public IList<StatDto> Stats { get; set; }
    }
}
