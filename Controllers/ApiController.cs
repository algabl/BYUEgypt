using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BYUEgypt.Controllers;


public class ApiController : Controller
{
    private readonly HttpClient _httpClient = new HttpClient();
    [HttpPost]
    public async Task<ActionResult> PostDataAction()
    {
        var requestUri = new Uri("https://api.byuegypt.com/predict"); // Replace with the URI of the REST API
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (string key in Request.Form.Keys) 
        { 
            dictionary.Add(key, Request.Form[key]);
        }

        var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var request = new HttpRequestMessage 
        { 
            Method = HttpMethod.Post, 
            RequestUri = requestUri, 
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
            
        HttpResponseMessage response = await _httpClient.SendAsync(request);
    
        if (response.IsSuccessStatusCode) 
        {
            string responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine("response: \t" + responseString);
            // var responseObject = JsonConvert.DeserializeObject(responseString);
            TempData["responseString"] = responseString;
            return RedirectToAction("SupAnalysis", "Analysis");
        }
        else 
        { // Handle error
            return BadRequest();
        }
    }
    
}