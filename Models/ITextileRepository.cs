namespace BYUEgypt.Models;

public interface ITextileRepository
{
    IQueryable<Textile> Textiles { get; }
    void DeleteRecord(Textile textile);
    IQueryable<Textile> GenerateQuery(Dictionary<string, string?> dict);
    
    void EditRecord(Textile textile);
    void CreateRecord(Textile textile); }
    