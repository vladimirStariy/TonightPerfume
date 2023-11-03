namespace TonightPerfume.Domain.Models
{
    public class Promocode
    {
        public uint Promocode_ID { get; set; }
        public string PromocodeBody { get; set; }
        public string Value { get; set; }
        public int UsingQuantity { get; set; }
        public int Circulation { get; set; }
        public bool isExpired { get; set; } = false;
        public DateTime ExpirationDate { get; set; }
    }
}
