using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Price
    {
        public uint Price_ID { get; set; }
        public uint Product_ID { get; set; }
        public uint Volume_ID { get; set; }
        public int Value { get; set; }
        public DateTime PriceDate { get; set; }
        public bool isActual { get; set; }

        [JsonIgnore]
        [ForeignKey("Product_ID")]
        public virtual Product? Product { get; set; }

        [JsonIgnore]
        [ForeignKey("Volume_ID")]
        public virtual Volume? Volume { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}