using BYUEgypt.Models.ViewModels;

namespace BYUEgypt.Models;

public class EFFullTextileRepository : IFullTextileRepository
{
    private FullTextileDbContext textileContext { get; set; }

    public EFFullTextileRepository(FullTextileDbContext temp)
    {
        textileContext = temp;
    }
    
    public IQueryable<Textile> Textiles => textileContext.Textiles;

    /*public IQueryable<FullTextile> GetTextiles(Dictionary<string, string?>? textileParams = null)
    {
        var query = textileContext.Textiles.AsQueryable()
            .Join(textileContext.ColorTextile,
                t => t.Id,
                ct => ct.MainTextileid,
                (t, ct) => new {t,ct})
            .Join(textileContext.Color,
                ct => ct.ct.MainColorid,
                c => c.Colorid,
                (ct, c) => new {ct,c})
            .Join(textileContext.DecorationTextile,
                t => t.Id,
                dt=> dt.MainTextileid,
                (t, dt) => new {t, dt})
            .Join(textileContext.Decoration,
                dt => dt.dt.MainDecorationid,
                d => d.Id,
                (dt, d) => new {dt, d})
            
        
    }*/
}