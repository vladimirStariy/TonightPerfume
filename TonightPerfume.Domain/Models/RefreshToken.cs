using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TonightPerfume.Domain.Models
{
    public class RefreshToken
    {
        [Key]
        public string Token { get; set; }
        public string DeviceData { get; set; }
        public uint User_ID { get; set; }
        [ForeignKey("User_ID")]
        public virtual BaseUser User { get; set; }
    }
}
