using System.Diagnostics;
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
    private ArtifactsContext artContext { get; set; }

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext temp, ArtifactsContext artTemp)
    {
        _logger = logger;
        context = temp;
        artContext = artTemp;
    }
    
    public IActionResult Index()
    {
        var viewModel = new ArtifactViewModel()
        {
            Artifacts = artContext.Artifacts
        };
        return View(viewModel);
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