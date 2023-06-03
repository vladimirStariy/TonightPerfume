using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonightPerfume.Domain.Models.User
{
    public class BaseUser
    {
        public uint User_ID { get; set; }
        //public DateTime RegistrationDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
