using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TonightPerfume.Domain.Models
{
    public class Profile
    {
        public uint Profile_ID { get; set; }
        public string? Firstname { get; set; }
        public string? Middlename { get; set; }
        public string? Lastname { get; set; }

        public DateTime? Birthday { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }

        public bool isFilled { get; set; } = false;

        public uint User_ID { get; set; }

        [JsonIgnore]
        [ForeignKey("User_ID")]
        public virtual BaseUser? User { get; set; }
    }
}
