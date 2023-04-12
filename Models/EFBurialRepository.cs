namespace BYUEgypt.Models;

public class EFBurialRepository : IBurialRepository
{
    private fagelgamous_databaseContext Context { get; set; }

    public EFBurialRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }

    public IQueryable<Burialmain> Burials => Context.Burialmains;
}