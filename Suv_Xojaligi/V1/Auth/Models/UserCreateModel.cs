using Suv_Xojaligi.Data.Entities.Commons;
using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Auth.Models
{
    public class UserCreateModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public OrderStatus UserRole { get; set; }
    }
}
