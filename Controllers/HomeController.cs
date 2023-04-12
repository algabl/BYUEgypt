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
        ViewData["Title"] = "Burial " + bm.Id;
        return View(bm);
    }
    

    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult EditRecord(long id)
    {
        Burialmain bm = repo.Burials.Single(x => x.Id == id);

        return View();
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult EditRecord()
    {
        return View();
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var artifact = artContext.Artifacts.Single(x => x.BurialId == id);
        ViewData["Title"] = "Delete " + artifact.Name;
        return View(artifact);
    }

    [HttpPost]
    public IActionResult Delete(Artifact artifact)
    {
        artifact = artContext.Artifacts.Single(x => x.BurialId == artifact.BurialId);
        artContext.Artifacts.Remove(artifact);
        artContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
}