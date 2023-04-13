using Microsoft.AspNetCore.Identity;

namespace BYUEgypt.Models.ViewModels;

public class UserViewModel
{
    public IdentityUser? User { get; set; }
    public string? Password { get; set; }
    public string? CurrentPassword { get; set; }
    public bool AdminRole { get; set; }
    public bool UserRole { get; set; }
}