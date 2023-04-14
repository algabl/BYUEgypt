namespace BYUEgypt.Models;

public interface ITextileRepository
{
    IQueryable<Textile> Textiles { get; }
    
}