using BYUEgypt.Models.ViewModels;

namespace BYUEgypt.Models;

public interface IFullTextileRepository
{
    public IQueryable<Textile> Textiles { get; }
    // public IQueryable<FullTextile> GetTextiles(Dictionary<string, string?>? textileParams = null);
}