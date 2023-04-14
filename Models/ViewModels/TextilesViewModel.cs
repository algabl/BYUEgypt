namespace BYUEgypt.Models.ViewModels;

public class TextilesViewModel
{
    public IQueryable<Textile> Textiles { get; set; }
    public PageInfo PageInfo { get; set; }
}