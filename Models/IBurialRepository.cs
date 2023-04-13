namespace BYUEgypt.Models;

public interface IBurialRepository
{
    IQueryable<Burialmain> Burials { get; }
    void DeleteRecord(Burialmain burial);

    IQueryable<Burialmain> GenerateQuery(Dictionary<string, string> dict, int pageSize = 5, int pageNum = 1);
}