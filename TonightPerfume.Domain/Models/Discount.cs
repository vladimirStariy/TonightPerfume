using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Discount
    {
        public uint Discount_ID { get; set; }

        public string Discount_Type { get; set; }

        public uint? Brand_ID { get; set; }
        public uint? User_ID { get; set; }
        public uint? Product_ID { get; set; }

        public int Value { get; set; }

        [JsonIgnore]
        [ForeignKey("User_ID")]
        public virtual BaseUser? User { get; set; }

        [JsonIgnore]
        [ForeignKey("Brand_ID")]
        public virtual Brand? Brand { get; set; }

        [JsonIgnore]
        [ForeignKey("Product_ID")]
        public virtual Product? Product { get; set; }


    }
}
