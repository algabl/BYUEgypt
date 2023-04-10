using BYUEgypt.Data;
using BYUEgypt.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BYUEgypt.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext _context;

    public AdminController(ILogger<HomeController> logger, ApplicationDbContext temp)
    {
        _logger = logger;
        _context = temp;
    }
    
    public IActionResult Users()
    {
        var viewModel = new UsersViewModel
        {
            Users = _context.Users
        };
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult UserForm()
    {
        return View(new IdentityUser());
    }

    [HttpPost]
    public IActionResult UserForm(IdentityUser user)
    {
        if (ModelState.IsValid)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

        return View(new IdentityUser());
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        var user = _context.Users.Single(x => x.Id == id);
        return View("UserForm", user);
    }

    [HttpPost]
    public IActionResult Edit(IdentityUser user)
    {
        if (ModelState.IsValid)
        {
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Users");
        }

        return View("UserForm", user);
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        var user = _context.Users.Single(x => x.Id == id);
        return View(user);
    }

    [HttpPost]
    public IActionResult Delete(IdentityUser user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Users");
    }
}