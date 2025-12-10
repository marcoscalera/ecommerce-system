// Data/EcommerceDbContext.cs
using Microsoft.EntityFrameworkCore;
using EcommerceSystem.Models;

namespace EcommerceSystem.Data;

public class EcommerceDbContext : DbContext
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey(i => i.PedidoId);
    }
}