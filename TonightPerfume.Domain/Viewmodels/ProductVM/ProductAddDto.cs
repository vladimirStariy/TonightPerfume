namespace TonightPerfume.Domain.Viewmodels.ProductVM
{
    public class PricesDto
    {
        public uint volumeId { get; set; }
        public int priceValue { get; set; }
    }

    public class ProductAddDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public string year { get; set; }
        public string country { get; set; }
        public uint category { get; set; }
        public uint brand { get; set; }
        public bool isPopular { get; set; }
        public bool isForOrder { get; set; }
        public ICollection<uint> groups { get; set; }
        public ICollection<uint> upperNotes { get; set; }
        public ICollection<uint> middleNotes { get; set; }
        public ICollection<uint> bottomNotes { get; set; }
        public ICollection<PricesDto>? Prices { get; set; }
    }
}
