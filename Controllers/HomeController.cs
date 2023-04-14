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

    
    // Universal actions
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    
    // Burial actions
    
    // Lists all burialmain records
    public IActionResult BurialRecords(int pageNum = 1)
    {
        int pageSize = 20;

        var viewModel = new BurialmainsViewModel
        {
            Burials = repo.Burials
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        
        return View("BurialRecordsList", viewModel);
    }

    // Returns a filtered list based on user-entered filters (filtering and pagination do not work at the same time because of the way our filters are structured
    public IActionResult BurialRecordsList(int pageNum = 1)
    {
        int pageSize = 20;

        Dictionary<string, string?> dict = new Dictionary<string, string?>();
        foreach (string key in Request.Form.Keys)
        {
            dict.Add(key, Request.Form[key]);
        }
        
        var viewModel = new BurialmainsViewModel
        {
            Burials = repo.GenerateQuery(dict)
                .OrderBy(bm => bm.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
                
        return View(viewModel);
    }

    // Individual view of burial record
    [HttpGet]
    public IActionResult RecordView(long id)
    {
        Burialmain bm = repo.Burials.Single(x => x.Id == id);
        ViewData["Title"] = "Burial " + bm.Id;
        return View(bm);
    }

    // Ability to create new burial record
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult CreateRecord()
    {
        Burialmain bm = new Burialmain();
        ViewData["Title"] = "Create new record";
        return View("BurialEdit", bm);
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
        return View("BurialEdit");
    }
    
    // Ability to edit existing burial records
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult BurialEdit(long id)
    {
        Burialmain bm = repo.Burials.Single(x => x.Id == id);
        ViewData["Title"] = "Edit " + bm.Id;
        return View(bm);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult BurialEdit(Burialmain burial)
    {
        if (ModelState.IsValid)
        {
            repo.EditRecord(burial);
            return RedirectToAction("RecordView", "Home", new { id = burial.Id});
        }
        ViewData["Title"] = "Edit " + burial.Id;
        return View();
    }
    
    // Ability to delete existing burial records
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
    
    // Textile actions
    
    // Lists all textile records
    public IActionResult TextileRecords(int pageNum = 1)
    {
        
        int pageSize = 20;
        var viewModel = new TextilesViewModel
        {
            Textiles = textileRepo.Textiles
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
            
            PageInfo = new PageInfo
            {
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        ViewData["Title"] = "Textiles";
        return View("TextileRecordsList", viewModel);
    }
    
    // This action *in the future* will  like BurialRecordsList, return a list of filtered textiles
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
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
        ViewData["Title"] = "Textiles";
        return View(viewModel);
    }
    
    // Ability to view single textile record
    public IActionResult TextileView(long id)
    {
        Textile tx = textileRepo.Textiles.Single(tx => tx.Id == id);
        ViewData["Title"] = "Textile " + tx.Id;
        return View(tx);
    }
    
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult CreateTextile()
    {
        Textile textile = new Textile();
        ViewData["Title"] = "Create new record";
        return View("TextileEdit", textile);
    }
    
    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult CreateTextile(Textile textile)
    {
        if (ModelState.IsValid)
        {
            textileRepo.CreateRecord(textile);
            return RedirectToAction("RecordView", "Home", new { id = textile.Id });
        }

        ViewData["Title"] = "Create new record";
        return View("TextileEdit");
    }
    
    [HttpGet]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult TextileEdit(long id)
    {
        Textile textile = textileRepo.Textiles.Single(x => x.Id == id);
        ViewData["Title"] = "Edit " + textile.Id;
        return View(textile);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult TextileEdit(Textile textile)
    {
        if (ModelState.IsValid)
        {
            textileRepo.EditRecord(textile);
            return RedirectToAction("TextileView", "Home", new { id = textile.Id});
        }
        ViewData["Title"] = "Edit " + textile.Id;
        return View();
    }

    [Authorize(Roles = "USER, ADMIN")]
    [HttpGet]
    public IActionResult TextileDelete(long id)
    {
        var textile = textileRepo.Textiles.Single(x => x.Id == id);
        ViewData["Title"] = "Delete " + textile.Id;
        return View(textile);
    }

    [HttpPost]
    [Authorize(Roles = "USER, ADMIN")]
    public IActionResult TextileDelete(Textile textile)
    {
        textile = textileRepo.Textiles.Single(x => x.Id == textile.Id);
        textileRepo.DeleteRecord(textile);
        return RedirectToAction("Index");
    }


    
    
    

}