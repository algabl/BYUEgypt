using Microsoft.EntityFrameworkCore;

namespace BYUEgypt.Models;

public class ArtifactContext : DbContext
{
    public ArtifactContext(DbContextOptions<ArtifactContext> options) : base(options)
    {
        // leavin blank
    }
    
    public DbSet<Artifact> Artifacts { get; set; }
}