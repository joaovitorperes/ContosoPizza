using ContosoPizza.Models;

namespace ContosoPizza.Repositories;

public interface IPizzaRepository
{
    Task<List<Pizza>> GetAllAsync();

    Task<Pizza?> GetByIdAsync(int id);

    Task AddAsync(Pizza pizza);

    Task UpdateAsync();

    Task DeleteAsync(Pizza pizza);
}