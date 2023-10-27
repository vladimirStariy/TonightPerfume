namespace TonightPerfume.Domain.Viewmodels.OrderVM
{
    public class AuthOrderRequestDto
    {
        public uint selectedAdress { get; set; }
        public string PaymentType { get; set; }
        public string DeliveryType { get; set; }
        public string? Note { get; set; }
    }
}
