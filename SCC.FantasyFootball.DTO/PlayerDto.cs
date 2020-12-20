using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.DTO
{
    public class PlayerDto
    {
        public int Playerid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public string College { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string[] Positions { get; set; }
        public string Status { get; set; }
        public short? DraftYear { get; set; }
        public DateTime Dob { get; set; }
        public string PlayingStatus { get; set; }

        public IList<StatDto> Stats { get; set; }
    }
}
