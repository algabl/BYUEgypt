﻿using System.Diagnostics;
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

    
    // Universal things
    
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


    
    // Burials
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
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
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
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
                CurrentPage = pageNum
            }
        };
                
        return View(viewModel);
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
    [Authorize(Roles = "USER, ADMIN")]
    [HttpGet]
    public IActionResult Delete(long id)
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
    
    // Textiles
    
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
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
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
                TotalNumRecords = repo.Burials.Count(),
                RecordsPerPage = pageSize,
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