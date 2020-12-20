using SCC.FantasyFootball.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [EnumDataType(typeof(PlayerPosition))]
        public PlayerPosition Positions { get; set; }
        [EnumDataType(typeof(PlayerStatus))]
        public PlayerStatus Status { get; set; }
        public short? DraftYear { get; set; }
        public DateTime Dob { get; set; }
        [EnumDataType(typeof(PlayerGameStatus))]
        public PlayerGameStatus PlayingStatus { get; set; }

        public IList<StatDto> Stats { get; set; }
    }
}
