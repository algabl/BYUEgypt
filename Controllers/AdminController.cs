using BYUEgypt.Data;
using BYUEgypt.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BYUEgypt.Controllers;

[Authorize(Roles = "ADMIN")]
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
                UserRole = _userManager.IsInRoleAsync(u, "USER").Result,
                AdminRole = _userManager.IsInRoleAsync(u, "ADMIN").Result
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
            var result = await _userManager.CreateAsync(viewModel.User, viewModel.Password);
            if (result.Succeeded)
            {
                if (viewModel.UserRole)
                    await _userManager.AddToRoleAsync(viewModel.User, "USER");
                if (viewModel.AdminRole)
                    await _userManager.AddToRoleAsync(viewModel.User, "ADMIN");
                return RedirectToAction("Users");
            }
            else
            {
                List<IdentityError> errorList = result.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                ModelState.AddModelError(string.Empty, errors);
            }
            
      


        }
        ViewBag.Roles = _roleManager.Roles.ToList();
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        ViewBag.Roles = _roleManager.Roles.ToList();
        ViewData["Title"] = "Edit";
        var user = _userManager.FindByIdAsync(id).Result;
        var viewModel = new UserViewModel()
        {
            User = user,
            UserRole = _userManager.IsInRoleAsync(user, "USER").Result,
            AdminRole = _userManager.IsInRoleAsync(user, "ADMIN").Result
        };
        return View("UserForm", viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(viewModel.User.Id);

            user.UserName = viewModel.User.UserName;
            user.Email = viewModel.User.Email;
            user.PhoneNumber = viewModel.User.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(viewModel.CurrentPassword))
                    await _userManager.ChangePasswordAsync(user, viewModel.CurrentPassword, viewModel.Password);
                if (viewModel.AdminRole)
                    await _userManager.AddToRoleAsync(user, "ADMIN");
                else
                    await _userManager.RemoveFromRoleAsync(user, "ADMIN");
                if (viewModel.UserRole)
                    await _userManager.AddToRoleAsync(user, "USER");
                else
                    await _userManager.RemoveFromRoleAsync(user, "USER");
                return RedirectToAction("Users");
            }

            List<IdentityError> errorList = result.Errors.ToList();
            var errors = string.Join(", ", errorList.Select(e => e.Description));
            ModelState.AddModelError(string.Empty, errors);

        }

        ViewData["Title"] = "Edit";
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