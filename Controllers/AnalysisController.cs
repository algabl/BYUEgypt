using System.Collections.Specialized;
using BYUEgypt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        List<string> HairColors = new List<string>{ "Brown (Dark and Tan)", "Undyed (white)", "Yellow/Green",
       "Black", "White (bleached linen)", "Red (for ribbon)", "Dark Tan",
       "Undyed", "Blue (Blue-Green)", "Green (avocado)",
       "Yellow (Gold decoration threads)", "Yellow (mustard)",
       "Purple (Blackish)", "White", "White (?)", "Purple (weft shots)",
       "Undyed (Ribbon - shroud)", "Red (ribbon)", "Undyed or white",
       "Green (olive green)",
       "Orange (Background for sewn on decorative band)",
       "Green (some decoration threads)",
       "Yellow - Gold decoration threads", "Black (hemming thread)",
       "Purple (tiny fragment - no context)",
       "Red (2 small wool threads)", "Green (two shades)",
       "Red (2 strands of red)", "Green (decorations)",
       "Yellow (decorations)", "Orange (repair)", "Red (Field Color)",
       "Red (1 red string)", "Red (inserted weft marking)",
       "Undyed (ribbon, shroud)",
       "Purple (or black single weft threads on decorative edge with open warps)",
       "Blue (navy)", "Red (26 cm)", "Brown (single shot)",
       "Undyed (ground)", "Purple", "Green", "Blue",
       "Green (same threads as purple/green)", "Purple/Green",
       "Purple (wool)", "Anoter", "Other - Lavender or red", "Red (?)",
       "Blue (dark)", "Yellow (threads)", "Undyed (linen)",
       "Yellow (one random 2-ply thread not woven into fabric)",
       "Red (weft band)", "Brown (2 stripes)", "Other - Tan",
       "Black (or blue or purple)", "Purple (probably overdyed)",
       "Purple (2 weft threads)", "Brown (possibly variegated)", "Orange",
       "Yellow (ochre)", "Other-peach", "Yellow", "Red", "Peach",
       "Red (orange)", "Yellow (possibly)", "White (bleached)",
       "Purple (?)", "Possibly White", "Undyed (?)",
       "Undyed (possibly bleached)", "Yellow, possibly",
       "Purple (thread)", "Red-Orange", "Other - Red-pink",
       "Yellow (2 ply wool)", "Blue (teal. Dark - discolored?)",
       "Brown (dark - discolored?)", "Red (Wool weft bands)",
       "Green (2 shades)", "Red (deep color - \"bluish\")",
       "Undyed (selvedge)", "Red (4)", "Undyed (darker)",
       "Other (Beige possibly, undyed linen)", "Blue (or dark green)",
       "Red/Orange", "White/Beige", "Yellow (gold)",
       "Yellow (darning/design)", "Undyed (Linen warps)",
       "Undyed (possibly white)", "Red?", "Red (wool thread)",
       "Red (small thread)", "Purple/Brown", "Blue (band)",
       "Brown (possible)", "Red (linen)", "Yellow (wool)", "Brown",
       "Yellow-gold", "Beige" };
        List<string> Structures = new List<string> {"Weft twining", "Tapestry: slit", "Basket weave (2 to 1)",
       "Sewn ?", "Darning ?", "Sewn", "Darning",
       "Ribbon technique (see 3.4)", "Decorative Band", "Weft-faced",
       "Pile: loop (colored)", "Weft ribs (4 thread)", "Braided fringe",
       "Plain weave: 1 over 1 (Blue background fabric)", "Floating warps",
       "Open warp (?)", "Weft ribs (approx. 10 threads)",
       "Basket weave 2 x 2", "warp faced", "Floating warps (10 cm)",
       "Plain weave: 1 over 1 (on shroud)", "Plain weave", "Stitched Hem",
       "Embroidery", "Weft ribs (see description)",
       "Weft ribs (2 shots of 4 threads in a series that repeats 9.5 cm apart)",
       "Basket weave (near bottom)",
       "Floating warps (weft bands of color)",
       "Hemmed edge on one fragment", "Basket weave (warp faced)",
       "Weft ribs (random - no pattern)", "Plain weave: 1over 2",
       "Plain weave: 1 over 1 (with random double thread wefts)",
       "Basket", "Ribbon technique (very loose)",
       "Basket weave: 2 over 1", "Soumack",
       "Plain weave: 1 over 2 (tapestry)", "Warp ribs",
       "Floating warps (on wool portion)", "Basket weave (2 over 2)",
       "Plain weave: 1 over 2 (some 2 over 2)", "Basket weave",
       "Plain weave: warp faced", "Plain weave: 1 over 1", "Weft ribs",
       "Plain weave: 1 over 2 warp", "Plain weave: weft faced (wool)",
       "Plain weave: 1 over 1 (gauze)", "Plain weave: weft faced",
       "Floating wefts", "Weft ribs (2 weft threads)",
       "Plain weave: 1 weft over 2 warp", "Rope",
       "Ribbon technique (but different)", "Ribbon technique",
       "Pile: loop", "Embroidery?", "Weft ribs (random, thicker threads)",
       "Open warp", "Pile: cut",
       "Floating warps (behind the purple bands)",
       "Possible compound weave", "Weft ribs (13 cm between series)",
       "Plain weave: 2 over 1", "Other - Possible Compound Weave",
       "Embroidery (?)", "Pile: looped", "Basket weave (mending?)",
       "Tapestry: slit (green meets yellow)",
       "Plain weave: 1 over 1 (Brown, .B)",
       "Plain weave: weft faced (yellow wool)", "Weft ribs (sets of 3)",
       "Plain weave: 1 over 2 warps",
       "Sewn (yellow wool, purple wool inserted)",
       "Other - hemmed opening", "Red", "Other - Braided Fringe",
       "Basket weave (2 x 2)",
       "Weft ribs (Larger fragment: 2x 2 2x 2 2x)",
       "Plain weave: 1 over 2 (Larger fragment--half basket)",
       "Basket weave (smaller fragment)",
       "Pile: loop (3.5cm length loop)", "Plain weave: 1 over 1 (orange)",
       "Plain weave: weft faced (green)", "Sewn (overcasting)",
       "Basket weave (2 over 1)", "Ribbon technique (braided)",
       "Weft ribs (on some)", "Sewn (whip stitch, running stitch)",
       "Sprang (Rope which is part of sprang fragment)",
       "Open warp - 3 cm", "Weft ribs (random, additional threads)",
       "Plain weave: 1 over 2, 3 and 4 warps", "Patched", "Weft ribs (?)",
       "Plain weave: 1 over 2 (warp)", "Weft ribs (2 threads)",
       "Plain weave: 1 over 1 (linen)", "Unknown",
       "Tapestry: interlocking", "Darning (?)", "Patched (?)",
       "Needlework", "Weft ribs (10 cm between series)",
       "Ribbon technique - plaited", "Weft ribs (4.5 cm between series)",
       "Basket weave (over face)", "Tapestry:slit", "Other - Ribbon",
       "Basket weave (unbalanced)", "Weft ribs (on plain weave)",
       "two fragments of rope", "Floating warps (sort of)",
       "Basket weave (2x2)", "Braided", "Torn strip binding",
       "Weft ribs (3x 2 3x 2 3x)", "Plain weave:1 warp over 2 red wefts",
       "Plain weave: weft faced (yellow)",
       "Plain weave: 1 over 1 (first shroud)",
       "Basket weave (for torn strips)", "Weft ribs (5 cm between)",
       "Weft ribs (every 2 cm)", "Weft ribs (x 2 x 2 x)",
       "Weft ribs (3x)", "Sewn: yellow and purple wool inserted",
       "Other: hemmed opening", "Soumak", "Tapestry: dovetail",
       "Plain weave: 1 over 2", "Ribbon technique (rope)", "Sprang"} ;
        List<string> Functions = new List<string> {"Fragmentary/Unknown", "Head covering", "Face bundle", "Cordage",
       "Ribbon", "Other - Rope", "Tunic", "Blanket/shroud", "Fragmentary",
       "Other-scarf", "Tunic - Possible", "Ribbon - Torn Strips",
       "Blanket/Shroud (basket weave)", "Tunic (?)",
       "Tunic - Fragmentary", "Ribbon (linen possibly used as ribbon)",
       "Tunic: one piece", "Tunic - Probable",
       "Fragment of Tunic Medallion", "Blanket/shroud (probable)",
       "Ribbon (over top of shroud)", "other", "Ribbon - Torn Strip",
       "Tunic (fragment)", "Ribbon - Rope", "Tunic: sewn (fragmentary)",
       "Ribbon (6 fragments)", "Other (line strip like a rope)",
       "Ribbon (functionally)", "Tunic (probably)",
       "Ribbon (linen strips used as)", "Other - Basket",
       "Other - face bundle", "Blanket/shroud (?)", "Other-rope",
       "Ribbon?", "Ribbon (Torn strips in a horizontal pattern)",
       "Ribbon (2 fragments)", "Blanket/shroud (full head to feet)",
       "Other? - Decoration", "Ribbon (same as .1)",
       "small fragment of plain weave", "Blanket/shroud (possible tunic)",
       "Torn strip (possible. Only small fragment)",
       "Fragment of a Tunic", "Tunic ?", "Fragmentary (6 pieces; tunic?)",
       "Fragmentary (medallion found on tunic)",
       "Face bundle (wrapped over it)", "Fragmentary (2)", "Rope",
       "Shroud", "Fragmentary (1 larger, 2 small)",
       "Ribbon (torn strip tied around shroud)", "Belt?",
       "Blanket/shroud (wad)", "Torn Strips", "Tunic (Likely)", "Tunic?",
       "Unknown (probably blanket/shroud)",
       "Tunic (possible, but only fragments)",
       "Fragmentary (2 pieces; tunic?)", "Ribbon (6, Cordage)",
       "Tunic: sewn", "Face bundle (probably part of stack)",
       "Belt (probable)", "Ribbon (fragment)", "Ribbon and rope",
       "Blanket/shroud ?", "Ribbon - Linen Strips",
       "Ribbon (4 fragments)", "Other (Possibly a shawl)",
       "Ribbon - plaited", "Other - Rope of Yellow and Green Wool",
       "Other - Torn Strip Binding", "Other - 1 Selvedge",
       "Ribbon - Strips", "Torn strip", "Ribbon (sisel rope)",
       "Ribbon - 2.5 cm wide", "Other - Leg padding",
       "Face Bundle - Sprang", "Other - Skull Cap",
       "Other - Fronts Piece", "Other - Torn Strips",
       "Ribbon - 5 twist single ply thread wrapped around 3 times"};
        List<string> Decorations = new List<string> {"Roundels", "Undyed", "Animal motifs", "Roundels (2)",
            "Other - Unknown", "Open warp (1.5 cm band)",
            "Flying Thread Brocades", "Other (applied pattern)",
            "Abstract motifs", "Plant Motifs (?)",
            "Other (inserted threads for repair and decoration)",
            "Weft bands (red)", "Cross", "Weft bands (woven in?)", "Weft ribs",
            "Single shot weft missing for linear design", "Plant motifs",
            "Human motifs", "Warp stripes", "Clavi",
            "Other (unknown - too fragmentary)", "Weft bands (one red)",
            "Weft bands", "Clavi?", "Open warp", "Plant motifs?",
            "Warp ribs (4)", "Other - Applied Pattern", "Other"};
        ViewBag.HairColors = HairColors;
        ViewBag.Structures = Structures;
        ViewBag.Functions = Functions;
        ViewBag.Decorations = Decorations;
        
        return View();
    }
    
   /*
    public async Task<IActionResult> PostDataAction()
    {
        using (var client = new HttpClient())
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
            
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                // var responseObject = JsonConvert.DeserializeObject(responseString);

                TempData["responseString"] = responseString;
                
                return RedirectToAction(responseString);
                
            }
            else
            {
                // Handle error
                return BadRequest();
            }
        }
    }
    */

   [HttpPost]
    public IActionResult SupAnalysis(string response)
    {
        string responseString = (string)TempData["responseString"];
        
        return View(responseString);
    }
    
    public IActionResult UnSupAnalysis()
    {
        return View();
    }   
}