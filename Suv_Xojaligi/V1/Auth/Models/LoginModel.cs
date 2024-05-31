using System.ComponentModel.DataAnnotations;

namespace Suv_Xojaligi.V1.Auth.Models;

public class LoginModel
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
