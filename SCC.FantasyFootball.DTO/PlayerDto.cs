using SCC.FantasyFootball.Common.Enums;
using SCC.FantasyFootball.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.DTO
{
    public record PlayerDto : IEntityRecord, ISelectAsItem
    {
        public int Id { get; set; }
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

        public KeyValuePair<string, string> AsKeyValuePair()
        {
            return new KeyValuePair<string, string>(Id.ToString(), $"{Lastname}, {Firstname} {Positions}");
        }

        public bool IsDirty(object obj)
        {
            //SInce I am using records I can project the properties that may in fact be different since they are not being sent back
            //from the Update. THen just veryifying everything else is a match. The equal operator for records matches exactly the same for the 
            //values that are in the object. 
            var original = (obj as PlayerDto) with { Stats = null, Createddate = DateTime.MinValue, Modifieddate = null };
            var current = this with { Stats = null, Createddate = DateTime.MinValue, Modifieddate = null };
            return original != current;
        }
    }
}
