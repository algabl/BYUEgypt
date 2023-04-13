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
    public IActionResult Index()
    {
        return View();
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

    public IActionResult BurialRecords()
    {
        int pageSize = 20;
        int pageNum = 1;
        var viewModel = new BurialmainsViewModel
        {
            
            // foreach (key in Request.Form.Keys)
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
        return View("BurialRecordsList", viewModel);
    }
    
    public IActionResult BurialRecordsList(int pageNum = 1)
    {
        int pageSize = 5;

        var Query = repo.Burials.AsQueryable();
        foreach (string key in Request.Form.Keys)
        {
            if (key.Substring(0, 3) != "ind")
            {
                if (Request.Form["indicator" + key] == "==") 
                {
                    Query.Where(bm => bm.GetType().GetProperty(key).GetValue(bm).ToString() == Request.Form[key]);
                } 
                else if (Request.Form["indicator" + key] == "!=") 
                {
                    Query.Where(bm => bm.GetType().GetProperty(key).GetValue(bm).ToString() != Request.Form[key]);
                } 
                else if (Request.Form["indicator" + key] == ">") 
                {
                    Query.Where(bm => ((double) bm.GetType().GetProperty(key).GetValue(bm)) > ((double)((object) Request.Form[key])));
                } 
                else if (Request.Form["indicator" + key] == "<") 
                {
                    Query.Where(bm => ((double) bm.GetType().GetProperty(key).GetValue(bm)) < ((double)((object) Request.Form[key])));
                } 
            }

            Query.Skip((pageNum - 1) * pageSize).Take(pageSize);
        }
        
        var viewModel = new BurialmainsViewModel
        {
            
            // foreach (key in Request.Form.Keys)
            Burialmains = Query,
            
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