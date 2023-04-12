namespace BYUEgypt.Models;

public interface IBurialRepository
{
    IQueryable<Burialmain> Burials { get; }
    void DeleteRecord(Burialmain burial);
    void EditRecord(Burialmain burial);
}