using Microsoft.AspNetCore.Identity;

namespace BYUEgypt.Models.ViewModels;

public class UserViewModel
{
    public IdentityUser User { get; set; }
    public string? CurrentPassword { get; set; }
    public string? Password { get; set; }
    public IList<string>? Roles { get; set; }
}