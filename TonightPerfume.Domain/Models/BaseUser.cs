namespace TonightPerfume.Domain.Models
{
    public class BaseUser
    {
        public uint User_ID { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
