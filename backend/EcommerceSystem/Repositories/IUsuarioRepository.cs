using EcommerceSystem.Models;

namespace EcommerceSystem.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByEmailAsync(string email);
    Task<Usuario> AddAsync(Usuario usuario);
}