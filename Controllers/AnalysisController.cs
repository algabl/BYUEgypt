using System.Collections.Specialized;
using BYUEgypt.Models;
using Microsoft.AspNetCore.Mvc;

namespace BYUEgypt.Controllers;

public class AnalysisController : Controller
{
    
    private IBurialRepository repo;
    private fagelgamous_databaseContext gamous_context;

    public AnalysisController(IBurialRepository burialTemp, fagelgamous_databaseContext gamousContext)
    {
        repo = burialTemp;
        gamous_context = gamousContext;
    }
    
    [HttpGet]
    public IActionResult SupAnalysis()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SupAnalysis(ListDictionary dictionary)
    {
        return View();
    }
    
    public IActionResult UnSupAnalysis()
    {
        return View();
    }   
}