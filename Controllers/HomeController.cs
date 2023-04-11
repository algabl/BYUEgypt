using System.Diagnostics;
using BYUEgypt.Data;
using Microsoft.AspNetCore.Mvc;
using BYUEgypt.Models;
using BYUEgypt.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BYUEgypt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext temp)
    {
        _logger = logger;
        context = temp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult RecordView()
    {
        return View();
    }
    
    [Authorize(Roles = "USER, ADMIN")]
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
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}