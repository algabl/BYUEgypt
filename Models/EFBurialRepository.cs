namespace BYUEgypt.Models;

public class EFBurialRepository : IBurialRepository
{
    private fagelgamous_databaseContext Context { get; set; }

    public EFBurialRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }

    public IQueryable<Burialmain> Burials => Context.Burialmains;
    public void DeleteRecord(Burialmain burial)
    {
        Context.Remove(burial);
        Context.SaveChanges();
    }

    public void EditRecord(Burialmain burial)
    {
        Context.Update(burial);
        Context.SaveChanges();
    }

    public void CreateRecord(Burialmain burial)
    {
        Context.Add(burial);
        Context.SaveChanges();
    }
}