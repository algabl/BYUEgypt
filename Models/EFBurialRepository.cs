namespace BYUEgypt.Models;

public class EFBurialRepository : IBurialRepository
{
    private fagelgamous_databaseContext context { get; set; }

    public EFBurialRepository(fagelgamous_databaseContext temp)
    {
        context = temp;
    }

    public IQueryable<Burialmain> Burials => context.Burialmains;
}