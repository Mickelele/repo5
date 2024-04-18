using System.ComponentModel.DataAnnotations;

namespace ANIMALS_DB.Models;

public class Animal
{
    [Required]
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    [MaxLength(200)]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
}