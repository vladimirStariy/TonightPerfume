namespace TonightPerfume.Domain.Viewmodels.OrderVM
{
    public class OrderRequestDto
    {
        public string? Firstname { get; set; }
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

        public string PaymentType { get; set; }

        public string DeliveryType { get; set; }

        public string? Note { get; set; }

        public string? promocode { get; set; } = null;

        public List<CartProductDto> products { get; set; }
    }
}
