using System.ComponentModel.DataAnnotations.Schema;

namespace TonightPerfume.Domain.Models
{
    public class OrderProduct
    {
        public uint OrderProduct_Id { get; set; }

        public uint Order_ID { get; set; }
        public uint Price_ID { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("Order_ID")]
        public virtual Order Order { get; set; }

        [ForeignKey("Price_ID")]
        public virtual Price Price { get; set; }
    }
}
