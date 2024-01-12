using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Product
    {
        public uint Product_ID { get; set; }
        
        public string Name { get; set; }

        public uint Category_ID { get; set; }
        public uint Brand_ID { get; set; }
        public string Country { get; set; }
        public string Year { get; set; }

        public bool isPopular { get; set; } = false;

        public bool isForOrder { get; set; } = false;

        public string ImagePath { get; set; } = "";
        public string thumbImagePath { get; set; } = "";

        public string Description { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Category Category { get; set; }

        [ForeignKey("Brand_ID")]
        public virtual Brand Brand { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductNotes> ProductNotes { get; set; }

        [JsonIgnore]
        public virtual ICollection<AromaGroup> AromaGroups { get; set; }
    }
}
