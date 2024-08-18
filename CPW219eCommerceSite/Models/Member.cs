using System.ComponentModel.DataAnnotations;

namespace CPW219eCommerceSite.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }
    }
}
