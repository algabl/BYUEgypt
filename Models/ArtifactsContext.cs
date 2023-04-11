using Microsoft.EntityFrameworkCore;

namespace BYUEgypt.Models;

public class ArtifactsContext : DbContext
{
    public ArtifactsContext(DbContextOptions<ArtifactsContext> options) : base(options)
    {
        // leavin blank
    }
    
    public DbSet<Artifact> Artifacts { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Artifact>().HasData(
            new Artifact
            {
                BurialId = 1, 
                Name = "John Smith",
                Area = "NE",
                BurialNumber = 456,
                Depth = "45ft 6in",
                Length = "10ft 3in",
                Preservation = "Tight wrap",
                Sex = "Male",
                AgeAtDeath = 53,
                HairColor = "Black",
                Text = "This is the first artifact",
                PhotoId = "somestring",
                ExcavationRecorder = "Michael Johnson",
            },
            new Artifact
            {
                BurialId = 2, 
                Name = "Mike Tyson",
                Area = "SW",
                BurialNumber = 314,
                Depth = "57ft 4in",
                Length = "12ft 8in",
                Preservation = "Medium wrap",
                Sex = "Female",
                AgeAtDeath = 46,
                HairColor = "Black",
                Text = "This is the seond artifact",
                PhotoId = "anotherstring",
                ExcavationRecorder = "Maggy Jones",
            },
            new Artifact
            {
                BurialId = 3, 
                Name = "Wendy Moseby",
                Area = "SE",
                BurialNumber = 678,
                Depth = "32ft 6in",
                Length = "80ft 3in",
                Preservation = "Loose wrap",
                Sex = "Female",
                AgeAtDeath = 63,
                HairColor = "Blonde",
                Text = "This is the third artifact",
                PhotoId = "athirdstring",
                ExcavationRecorder = "Cyndi Lauper",
            }
            );

    }
}