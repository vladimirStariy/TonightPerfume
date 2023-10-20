using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.UserVM
{
    public class LoginResponseDto
    {
        public IDictionary<string, string> tokenPairs { get; set; }
        public ResponseUserDto user { get; set; }
    }

    public class ResponseUserDto
    {
        public uint id { get; set; }
        public string phone { get; set; }
    }

    public class LoginResponse
    {
        public string access { get; set; }
    }
}
