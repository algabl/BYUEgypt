﻿using System.Diagnostics;
using BYUEgypt.Data;
using Microsoft.AspNetCore.Mvc;
using BYUEgypt.Models;
using BYUEgypt.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;


namespace BYUEgypt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext context;
    private ArtifactContext artContext { get; set; }

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext temp, ArtifactContext artTemp)
    {
        _logger = logger;
        context = temp;
        artContext = artTemp;
    }
    
    public IActionResult Index()
    {
        var artifacts = artContext.Artifacts.ToList();
        return View(artifacts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult RecordView()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult EditRecord()
    {
        return View();
    }
    
    public IActionResult SupAnalysis()
    {
        return View();
    }
    
    public IActionResult UnSupAnalysis()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Users()
    {
        var viewModel = new UsersViewModel
        {
            Users = context.Users
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
            context.Add(user);
            context.SaveChanges();
            return RedirectToAction("Users");
        }

        return View(new IdentityUser());
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}