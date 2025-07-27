using Netflix_n_Chill.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netflix_n_Chill.Models
{
    [Table("Users")]
    public class Users : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}
