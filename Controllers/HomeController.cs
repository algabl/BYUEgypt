using System.Diagnostics;
using BYUEgypt.Data;
using Microsoft.AspNetCore.Mvc;
using BYUEgypt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using BYUEgypt.Models.ViewModels;


namespace BYUEgypt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IBurialRepository repo;
    private fagelgamous_databaseContext gamous_context;

    public HomeController(ILogger<HomeController> logger, IBurialRepository burialTemp, fagelgamous_databaseContext gamousContext)
    {
        _logger = logger;
        repo = burialTemp;
        gamous_context = gamousContext;
    }
    
    public IActionResult Index(int pageNum = 1)
    {
        int pageSize = 5;

        var Burialmains = gamous_context.Burialmains
            .Where(bm => bm.Area != "SW")
            .OrderBy(bm => bm.Burialnumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
                
        return View(Burialmains);
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
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
}