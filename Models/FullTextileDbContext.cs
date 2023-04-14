using BYUEgypt.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BYUEgypt.Models;

public class FullTextileDbContext : DbContext
{
    public FullTextileDbContext(DbContextOptions<FullTextileDbContext> options) : base(options)
    {
        // leavin blank
    }
    
    public virtual DbSet<Textile> Textiles { get; set; }
    public virtual DbSet<Burialmain> Burialmains { get; set; }
    public virtual DbSet<BurialmainTextile> BurialmainTextile { get; set; }
    public virtual DbSet<Decoration> Decoration { get; set; }
    public virtual DbSet<DecorationTextile> DecorationTextile { get; set; }
    public virtual DbSet<Color> Color { get; set; }
    public virtual DbSet<ColorTextile> ColorTextile { get; set; }
    
}