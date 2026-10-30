using ContosoPizza.Dtos;
using ContosoPizza.Models;
using ContosoPizza.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaRepository _repository;

    public PizzaController(IPizzaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaDto>>> GetAll()
    {
        var pizzasDb = await _repository.GetAllAsync();

        var pizzas = pizzasDb
            .Select(p => new PizzaDto
            {
                Id = p.Id,
                Name = p.Name!,
                IsGlutenFree = p.IsGlutenFree
            })
            .ToList();

        return pizzas;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PizzaDto>> Get(int id)
    {
        var pizza = await _repository.GetByIdAsync(id);

        if (pizza == null)
            return NotFound();

        return new PizzaDto
        {
            Id = pizza.Id,
            Name = pizza.Name!,
            IsGlutenFree = pizza.IsGlutenFree
        };
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePizzaDto dto)
    {
        var pizza = new Pizza
        {
            Name = dto.Name,
            IsGlutenFree = dto.IsGlutenFree
        };

        await _repository.AddAsync(pizza);

        var pizzaDto = new PizzaDto
        {
            Id = pizza.Id,
            Name = pizza.Name!,
            IsGlutenFree = pizza.IsGlutenFree
        };

        return CreatedAtAction(
            nameof(Get),
            new { id = pizza.Id },
            pizzaDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePizzaDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var existingPizza = await _repository.GetByIdAsync(id);

        if (existingPizza is null)
            return NotFound();

        existingPizza.Name = dto.Name;
        existingPizza.IsGlutenFree = dto.IsGlutenFree;

        await _repository.UpdateAsync();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _repository.GetByIdAsync(id);

        if (pizza is null)
            return NotFound();

        await _repository.DeleteAsync(pizza);

        return NoContent();
    }
}