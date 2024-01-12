using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class PerfumeNote
    {
        public uint Note_ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<ProductNotes> ProductNotes { get; } = new List<ProductNotes>();
    }
}
