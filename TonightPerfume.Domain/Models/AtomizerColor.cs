using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class AtomizerColor
    {
        public uint AtomizerColor_ID { get; set; }
        public string Color { get; set; }

        public uint Volume_ID { get; set; }
        [JsonIgnore]
        [ForeignKey("Volume_ID")]
        public virtual Volume? Volume { get; set; }
    }
}
