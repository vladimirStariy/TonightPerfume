namespace TonightPerfume.Domain.Viewmodels.ProfileVM
{
    public class OrderProductDto
    {
        public uint productId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string productName { get; set; }
        public string productBrand { get; set; }
        public string image { get; set; }
    }
}
