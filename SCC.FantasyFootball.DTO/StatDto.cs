using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.DTO
{
    public class StatDto
    {
        public int Gameid { get; set; }
        public int Teamid { get; set; }
        public int Playerid { get; set; }
        public short Passingattempts { get; set; }
        public short Passingcompletions { get; set; }
        public short Passingyards { get; set; }
        public short Passingytds { get; set; }
        public short Interceptions { get; set; }
        public short Fumbles { get; set; }
        public short Receptions { get; set; }
        public short Targets { get; set; }
        public short Drops { get; set; }
        public short Receivingyards { get; set; }
        public short Receivingtds { get; set; }
        public short Rushingattempts { get; set; }
        public short Rushingyards { get; set; }
        public short Rushingtds { get; set; }
        public short Otheryards { get; set; }
        public short Othertds { get; set; }
        public short Twopointconversion { get; set; }
        public decimal Points { get; set; }
        public short? Rztarget { get; set; }
        public short? Rzrush { get; set; }
        public bool Started { get; set; }
        public short Snaps { get; set; }

        public GameDto Game { get; set; }
        public PlayerDto Player { get; set; }
        public TeamDto Team { get; set; }
    }
}
