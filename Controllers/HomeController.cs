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

    public HomeController(ILogger<HomeController> logger, IBurialRepository burialTemp)
    {
        _logger = logger;
        repo = burialTemp;
    }

    
    [HttpGet]
    public IActionResult Index( int pageNum = 1)
    {
        /*foreach (string key in Request.Form.Keys)
        {
            dictionary.Add(key, Request.Form[key]);
        }*/
        int pageSize = 5;
        var viewModel = new BurialmainsViewModel
        {
            
            Burialmains = repo.Burials
                .OrderBy(bm => bm.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
            TotalNumBurials = repo.Burials.Count(),
            BurialsPerPage = pageSize,
            CurrentPage = pageNum
            }
        };
                
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(int pageNum = 1, int pageSize = 5)
    {
        
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string key in Request.Form.Keys)
        {
            dictionary.Add(key, Request.Form[key]);
        }
        var viewModel = new BurialmainsViewModel
        {
            
            Burialmains = repo.GenerateQuery(dictionary, pageSize, pageNum),
            
            PageInfo = new PageInfo
            {
                TotalNumBurials = repo.Burials.Count(),
                BurialsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        
        return View(viewModel);
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
        var burial = repo.Burials.Single(x => x.Id == id);
        ViewData["Title"] = "Delete " + burial.Id;
        return View(burial);
    }

    [HttpPost]
    public IActionResult Delete(Burialmain burial)
    {
        burial = repo.Burials.Single(x => x.Id == burial.Id);
        return RedirectToAction("Index");
    }
    
}