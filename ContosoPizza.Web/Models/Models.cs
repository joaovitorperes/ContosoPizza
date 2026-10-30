namespace ContosoPizza.Web.Models;

public class CreatePizzaDto
{
    public string Name { get; set; } = string.Empty;

    public bool IsGlutenFree { get; set; }
}
