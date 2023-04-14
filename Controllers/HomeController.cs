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
    private ITextileRepository textileRepo;

    public HomeController(ILogger<HomeController> logger, IBurialRepository burialTemp, ITextileRepository textileTemp)
    {
        _logger = logger;
        repo = burialTemp;
        textileRepo = textileTemp;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult BurialRecords()
    {
        int pageSize = 20;
        int pageNum = 1;
        
        var viewModel = new BurialmainsViewModel
        {
            Burials = repo.Burials
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
                TotalNumBurials = repo.Burials.Count(),
                BurialsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        
        return View("BurialRecordsList", viewModel);
    }
    
    public IActionResult BurialRecordsList(int pageNum = 1)
    {
        int pageSize = 20;

        Dictionary<string, string?> dict = new Dictionary<string, string?>();
        foreach (string key in Request.Form.Keys)
        {
            dict.Add(key, Request.Form[key]);
        }

        // IQueryable<Burialmain> query = repo.GenerateQuery(dict);

        var viewModel = new BurialmainsViewModel
        {
            Burials = repo.GenerateQuery(dict)
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
    public IActionResult TextileRecords()
    {
        
        int pageSize = 20;
        int pageNum = 1;
        
        var viewModel = new TextilesViewModel
        {
            Textiles = textileRepo.Textiles
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
                TotalNumBurials = repo.Burials.Count(),
                BurialsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        return View("TextileRecordsList", viewModel);
    }
    public IActionResult TextileRecordsList(int pageNum = 1)
    {
        int pageSize = 20;

        var viewModel = new TextilesViewModel
        {
            Textiles = textileRepo.Textiles
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

    public IActionResult TextileView(long id)
    {
        Textile tx = textileRepo.Textiles.Single(tx => tx.Id == id);
        ViewData["Title"] = "Textile " + tx.Id;
        return View(tx);
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
    public IActionResult CreateRecord()
    {
        Burialmain bm = new Burialmain();
        return View("EditRecord", bm);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult CreateRecord(Burialmain burial)
    {
        if (ModelState.IsValid)
        {
            repo.CreateRecord(burial);
            return RedirectToAction("RecordView", "Home", new { id = burial.Id });
        }

        ViewData["Title"] = "Create new record";
        return View("EditRecord");
    }
    
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult EditRecord(long id)
    {
        Burialmain bm = repo.Burials.Single(x => x.Id == id);

        return View(bm);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult EditRecord(Burialmain burial)
    {
        if (ModelState.IsValid)
        {
            repo.EditRecord(burial);
            return RedirectToAction("RecordView", "Home", new { id = burial.Id});
        }
        ViewData["Title"] = "Edit " + burial.Id;
        return View();
    }
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize(Roles = "USER, ADMIN")]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var burial = repo.Burials.Single(x => x.Id == id);
        ViewData["Title"] = "Delete " + burial.Id;
        return View(burial);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult Delete(Burialmain burial)
    {
        burial = repo.Burials.Single(x => x.Id == burial.Id);
        repo.DeleteRecord(burial);
        return RedirectToAction("Index");
    }
}