using System.ComponentModel.DataAnnotations;

namespace BYUEgypt.Models;

public class Artifact
{
    [Key]
    [Required]
    public int ArtifactId { get; set; }
    
    public string Name { get; set; }
    
}