using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Dtos;

public class UpdatePizzaDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public bool IsGlutenFree { get; set; }
}