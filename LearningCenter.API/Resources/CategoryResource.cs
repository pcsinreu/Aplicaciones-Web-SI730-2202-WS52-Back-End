using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Resources;

public class CategoryResource
{
    [Required]
    [MaxLength(10)]
    public string Name { get; set; }

    [Required]
    [MaxLength(150)]
    public string Description { get; set; }
    
    [Required]
    public int Quantity { get; set; }
}