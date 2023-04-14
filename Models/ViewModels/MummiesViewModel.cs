namespace BYUEgypt.Models.ViewModels;

public class MummiesViewModel
{
    public IQueryable<Mummy> Mummies { get; set; }
    public PageInfo PageInfo { get; set; }
}