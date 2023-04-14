using Microsoft.EntityFrameworkCore;

namespace BYUEgypt.Models;

public class MummyDbContext : DbContext
{
    public MummyDbContext(DbContextOptions<MummyDbContext> options) : base(options)
    {
        // leavin blank
    }
    
    public virtual DbSet<Burialmain> Burialmains { get; set; }
    public virtual DbSet<BurialmainTextile> BurialmainTextiles { get; set; }
    public virtual DbSet<Textile> Textiles { get; set; }
    
}