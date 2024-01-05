using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.ProductVM
{
    public class ProductCardDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; } 
        public int Price { get; set; }
        public int Discount { get; set; }
        public List<Price> Prices { get; set; }
        public bool isFavorite { get; set; } = false;
        public string imagePath { get; set; }
    }
}