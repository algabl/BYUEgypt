namespace BYUEgypt.Models;

public class EFTextileRepository : ITextileRepository
{
    private fagelgamous_databaseContext Context { get; set; }
    public EFTextileRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }
    
    public IQueryable<Textile> Textiles => Context.Textiles;
    
}