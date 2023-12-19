namespace TonightPerfume.Domain.Viewmodels.ProfileVM
{
    public class UserOrderCardDto
    {
        public uint OrderId { get; set; }    
        public DateTime OrderDate { get; set; }
        public int OrderPrice { get; set; }
        public string Status { get; set; }
    }
}
