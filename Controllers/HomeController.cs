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
    private ApplicationDbContext context;
    private IBurialRepository repo;
    private fagelgamous_databaseContext gamous_context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext temp, IBurialRepository burialTemp, fagelgamous_databaseContext gamousContext)
    {
        _logger = logger;
        context = temp;
        repo = burialTemp;
        gamous_context = gamousContext;
    }
    
    public IActionResult Index(int pageNum = 1)
    {
        int pageSize = 5;

        var burialmains = gamous_context.Burialmains
            .Where(bm => bm.Area != "NW")
            .OrderBy(bm => bm.Burialnumber)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize);
                
        return View(burialmains);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult RecordView(long id)
    {
        Burialmain bm = repo.Burials.Single(x => x.Id == id);
        return View(bm);
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