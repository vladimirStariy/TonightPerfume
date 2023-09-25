using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Brand
    {
        public uint Brand_ID { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
