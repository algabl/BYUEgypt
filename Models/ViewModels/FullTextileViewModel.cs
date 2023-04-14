namespace BYUEgypt.Models.ViewModels;

public class FullTextileViewModel
{
    public IQueryable<FullTextile> Textiles { get; set; }
    public PageInfo PageInfo { get; set; }
}