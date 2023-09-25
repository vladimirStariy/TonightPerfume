using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class AromaGroup
    {
        public uint AromaGroup_ID { get; set; }
        public string AromaGroup_Name { get; set; }

        [JsonIgnore]
        public virtual List<Product> Products { get; } = new List<Product>();
    }
}
