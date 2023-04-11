using BYUEgypt.Data;
using BYUEgypt.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BYUEgypt.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private UserManager<IdentityUser> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    public AdminController(ILogger<HomeController> logger, UserManager<IdentityUser> usrMg, RoleManager<IdentityRole> rolMg)
    {
        _logger = logger;
        _userManager = usrMg;
        _roleManager = rolMg;
    }
    
    public IActionResult Users()
    {
        var userList = _userManager.Users;
        var users = new List<UserViewModel>();
        foreach (var u in userList)
        {
            var viewModel = new UserViewModel()
            {
                User = u,
                Roles = _userManager.GetRolesAsync(u).Result
            };
            users.Add(viewModel);
        }
        return View(users);
    }

    [HttpGet]
    public IActionResult UserForm()
    {
        ViewBag.Roles = _roleManager.Roles;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UserForm(UserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            viewModel.User.Id = Guid.NewGuid().ToString();
            await _userManager.CreateAsync(viewModel.User, viewModel.Password);
            await _userManager.AddToRolesAsync(viewModel.User, viewModel.Roles);
      

            return RedirectToAction("Users");
        }
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View();
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        ViewBag.Roles = _roleManager.Roles.ToList();
        var user = _userManager.FindByIdAsync(id).Result;
        var viewModel = new UserViewModel()
        {
            User = user,
            Roles = _userManager.GetRolesAsync(user).Result
        };
        return View("UserForm", viewModel);
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel viewModel, List<string> newRoles)
    {
        if (ModelState.IsValid)
        {
            var user = viewModel.User;
            _userManager.UpdateAsync(user);
            if (!string.IsNullOrEmpty(viewModel.CurrentPassword))
                _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.Password);
            var oldRoles = _userManager.GetRolesAsync(user).Result;
            foreach (string r in newRoles)
            {
                if (!oldRoles.Contains(r))
                {
                    _userManager.AddToRoleAsync(user, r);
                }
            }
            foreach ( string r in oldRoles )
                if (!newRoles.Contains(r))
                {
                    _userManager.RemoveFromRoleAsync(user, r);
                }
            return RedirectToAction("Users");
        }
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View("UserForm", viewModel);
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        var user = _userManager.FindByIdAsync(id).Result;
        return View(user);
    }

    [HttpPost]
    public IActionResult Delete(IdentityUser user)
    {
        user = _userManager.FindByIdAsync(user.Id).Result;
        _userManager.DeleteAsync(user);
        return RedirectToAction("Users");
    }
}