using System.Linq;

namespace BYUEgypt.Models.ViewModels;

public class ArtifactViewModel
{
    public IQueryable<Artifact> Artifacts { get; set; }
    public PageInfo PageInfo { get; set; }
}