using Microsoft.EntityFrameworkCore;
using EcommerceSystem.Data;
using EcommerceSystem.Repositories;
using EcommerceSystem.Services;
using EcommerceSystem.Models; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQLite Database
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlite("Data Source=ecommerce.db"));

// Register Repositories (Repository Pattern)
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Register Services
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<CarrinhoService>();
builder.Services.AddScoped<CheckoutService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Initialize Database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
    context.Database.EnsureCreated();
    DatabaseSeeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();
app.Run();

// DatabaseSeeder.cs
public static class DatabaseSeeder
{
    public static void Seed(EcommerceDbContext context)
    {
        if (context.Produtos.Any()) return;

        var produtos = new[]
        {
            new Produto { Nome = "Notebook Dell", Descricao = "Intel i7, 16GB RAM", Preco = 4500.00m, Estoque = 10, ImagemUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400" },
            new Produto { Nome = "Mouse Logitech", Descricao = "Wireless, RGB", Preco = 150.00m, Estoque = 50, ImagemUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db?w=400" },
            new Produto { Nome = "Teclado Mecânico", Descricao = "Cherry MX Blue", Preco = 350.00m, Estoque = 30, ImagemUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=400" },
            new Produto { Nome = "Monitor LG 27\"", Descricao = "4K, 144Hz", Preco = 2200.00m, Estoque = 15, ImagemUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400" },
            new Produto { Nome = "Headset Gamer", Descricao = "7.1 Surround Sound", Preco = 280.00m, Estoque = 25, ImagemUrl = "https://images.unsplash.com/photo-1599669454699-248893623440?w=400" },
            new Produto { Nome = "Webcam HD", Descricao = "1080p, 60fps", Preco = 420.00m, Estoque = 20, ImagemUrl = "https://images.unsplash.com/photo-1587825140708-dfaf72ae4b04?w=400" }
        };

        context.Produtos.AddRange(produtos);
        context.SaveChanges();
    }
}