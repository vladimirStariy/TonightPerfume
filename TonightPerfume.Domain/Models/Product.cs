using System.ComponentModel.DataAnnotations.Schema;

namespace TonightPerfume.Domain.Models
{
    public class Product
    {
        public uint Product_ID { get; set; }
        public string Name { get; set; }
        public int Articul { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsNovation { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }

        public bool IsDiscounted { get; set; }

        public uint Brand_ID { get; set; }
        [ForeignKey("Brand_ID")]
        public virtual Brand Brand { get; set; }

        public uint Category_ID { get; set; }
        [ForeignKey("Brand_ID")]
        public virtual Category Category { get; set; }

    }
}
