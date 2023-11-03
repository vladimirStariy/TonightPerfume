namespace TonightPerfume.Domain.Viewmodels.ProfileVM
{
    public class ProfileAdressDto
    {
        public uint Id { get; set; }

        public string? Name { get; set; }

        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Appartaments { get; set; }
        public int? DomophoneCode { get; set; }
        public int? Entrance { get; set; }
        public int? Floor { get; set; }

        public int DeliveryType { get; set; }

        public string? PostNumber { get; set; }
    }
}
