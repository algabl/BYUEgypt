namespace BYUEgypt.Models;

public class EFTextileRepository : ITextileRepository
{
    private fagelgamous_databaseContext Context { get; set; }
    public EFTextileRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }


    public IQueryable<Textile> GenerateQuery(Dictionary<string, string?> dict)
    {
        var queryable = Context.Textiles.AsQueryable();

        return queryable;
    }
    
    public void EditRecord(Textile textile)
    {
        Context.Update(textile);
        Context.SaveChanges();
    }

    public void CreateRecord(Textile textile)
    {
        Context.Add(textile);
        Context.SaveChanges();
    }

    public void DeleteRecord(Textile textile)
    {
        Context.Remove(textile);
        Context.SaveChanges();
    }
    public IQueryable<Textile> Textiles => Context.Textiles;
    
}