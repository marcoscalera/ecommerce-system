using EcommerceSystem.Models;

namespace EcommerceSystem.Repositories;

public interface IPedidoRepository
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(int id);
    Task<Pedido> AddAsync(Pedido pedido);
}