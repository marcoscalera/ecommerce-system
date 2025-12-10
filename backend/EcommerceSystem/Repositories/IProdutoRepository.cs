using EcommerceSystem.Models;

namespace EcommerceSystem.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(int id);
    Task<Produto> AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(int id);
}