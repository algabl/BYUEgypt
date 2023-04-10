using Microsoft.AspNetCore.Identity;

namespace BYUEgypt.Models.ViewModels;

public class UsersViewModel
{
    public IQueryable<IdentityUser> Users { get; set; }
}