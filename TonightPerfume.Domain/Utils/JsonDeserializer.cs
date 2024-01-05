using System.Text.Json;
using TonightPerfume.Domain.Viewmodels.ProductVM;

namespace TonightPerfume.Domain.Utils
{
    public static class JsonDeserializer
    {
        public static PricesDto DeserializePricesJson(string jsonString)
        {
            var price = JsonSerializer.Deserialize<PricesDto>(jsonString);
            return price;
        }
    }
}
