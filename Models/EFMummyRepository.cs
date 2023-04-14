using BYUEgypt.Models.ViewModels;

namespace BYUEgypt.Models;

public class EFMummyRepository : IMummyRepository
{
    
    private MummyDbContext mummyContext { get; set; }

    public EFMummyRepository(MummyDbContext temp)
    {
        mummyContext = temp;
    }

    public IQueryable<Burialmain> Mummies => mummyContext.Burialmains;
    public IQueryable<Mummy> GetBurials(Dictionary<string, string?>? burialParams = null)
    {
        var query = mummyContext.Burialmains
            .Join(mummyContext.BurialmainTextiles,
                bm => bm.Id,
                bt => bt.MainBurialmainid,
                (bm, bt) => new { bm, bt })
            .Join(
                mummyContext.Textiles,
                b => b.bt.MainTextileid,
                t => t.Id,
                (b, t) => new { b, t })
            .Select(x => new Mummy {
                    Id = x.b.bm.Id,
                    Ageatdeath = x.b.bm.Ageatdeath,
                    Haircolor = x.b.bm.Haircolor,
                    Sex = x.b.bm.Sex,
                    Wrapping = x.b.bm.Wrapping,
                    Depth = x.b.bm.Depth,
                    Northsouth = x.b.bm.Northsouth,
                    Squarenorthsouth = x.b.bm.Squarenorthsouth,
                    Eastwest = x.b.bm.Eastwest,
                    Squareeastwest = x.b.bm.Squareeastwest,
                    Area = x.b.bm.Area,
                    Textileid = x.b.bt.MainTextileid,
                    TextileDescription = x.t.Description });
        
        if (burialParams != null)
        {
            query = !string.IsNullOrEmpty(burialParams?["Ageatdeath"])
                ? query.Where(m => m.Ageatdeath == burialParams["Ageatdeath"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Haircolor"])
                ? query.Where(m => m.Haircolor == burialParams["Haircolor"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Sex"])
                ? query.Where(m => m.Sex == burialParams["Sex"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Wrapping"])
                ? query.Where(m => m.Wrapping == burialParams["Wrapping"])
                : query;

            double result;
            query = !string.IsNullOrEmpty(burialParams?["Depth"])
                ? ( query.AsEnumerable().Where(m => 
                        double.TryParse(m.Depth, out result)
                            ? (result > double.Parse(burialParams["Depth"]) && result < (double.Parse(burialParams["Depth"]) + 0.5))
                            : false )
                ).AsQueryable()
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Northsouth"])
                ? query.Where(m => m.Northsouth == burialParams["Northsouth"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Squarenorthsouth"])
                ? query.Where(m => m.Squarenorthsouth == burialParams["Squarenorthsouth"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Eastwest"])
                ? query.Where(m => m.Eastwest == burialParams["Eastwest"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Squareeastwest"])
                ? query.Where(m => m.Squareeastwest == burialParams["Squareeastwest"])
                : query;
            query = !string.IsNullOrEmpty(burialParams?["Area"])
                ? query.Where(m => m.Area == burialParams["Area"])
                : query;
        }

        return query;
    }
}