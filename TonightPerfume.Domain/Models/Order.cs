using Newtonsoft.Json;

namespace TonightPerfume.Domain.Models
{
    public class Order
    {
        public uint Order_ID { get; set; }

        public DateTime Order_date { get; set; }
        public bool isNew { get; set; }

        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Appartaments { get; set; }
        public int? DomophoneCode { get; set; }
        public int? Entrance { get; set; }
        public int? Floor { get; set; }

        public string? PostNumber { get; set; }

        public string DeliveryType { get; set; }

        public string? Note { get; set; }

        public string? PaymentType { get; set; }

        public string Promocode { get; set; }

        public int? SummaryPrice { get; set; }

        public bool isCompleted { get; set; } = false;
        public bool isCanceled { get; set; } = false;

        public DateTime? OrderCompleteDate { get; set; }

        public uint? User_ID { get; set; }
        

        [JsonIgnore]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
