namespace ContosoPizza.Web.Models;

public class UpdatePizzaDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsGlutenFree { get; set; }
}