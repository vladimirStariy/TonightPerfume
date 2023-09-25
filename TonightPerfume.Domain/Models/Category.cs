using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Category
    {
        public uint Category_ID { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
