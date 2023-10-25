using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Adress
    {
        public uint Adress_ID { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Appartaments { get; set; }
        public int? DomophoneCode { get; set; }
        public int? Entrance { get; set; }
        public int? Floor { get; set; }

        public string? PostNumber { get; set; }

        public uint Profile_ID { get; set; }

        [JsonIgnore]
        [ForeignKey("Profile_ID")]
        public virtual Profile? Profile { get; set; }
    }
}
