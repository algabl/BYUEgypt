namespace BYUEgypt.Models;

public interface IBurialRepository
{
    IQueryable<Burialmain> Burials { get; }
    void DeleteRecord(Burialmain burial);
    IQueryable<Burialmain> GenerateQuery(Dictionary<string, string?> dict);
    
    void EditRecord(Burialmain burial);
    void CreateRecord(Burialmain burial); }