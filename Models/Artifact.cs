using System.ComponentModel.DataAnnotations;

namespace BYUEgypt.Models;

public class Artifact
{
    [Key]
    [Required]
    public int BurialId { get; set; }
    
    public string? Name { get; set; }
    public string? Area { get; set; }
    public int? BurialNumber { get; set; }
    public string? Depth { get; set; }
    public string? Length { get; set; }
    public string? Preservation { get; set; }
    public string? Sex { get; set; }
    public int? AgeAtDeath { get; set; }
    public string? HairColor { get; set; }
    public string? Text { get; set; }
    public string? PhotoId { get; set; }
    public string? ExcavationRecorder { get; set; }
}