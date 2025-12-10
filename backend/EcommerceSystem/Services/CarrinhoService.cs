using EcommerceSystem.Repositories;
using EcommerceSystem.ViewModels;
using EcommerceSystem.Patterns.Strategy;

namespace EcommerceSystem.Services;

public class CarrinhoService
{
    private readonly IProdutoRepository _produtoRepository;

    public CarrinhoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public Task<CarrinhoViewModel> CalcularCarrinhoAsync(List<ItemCarrinhoViewModel> itens, string tipoFrete = "PAC")
    {
        decimal subtotal = itens.Sum(i => i.Subtotal);
        
        var estrategiaFrete = FreteFactory.CriarEstrategia(tipoFrete);
        decimal valorFrete = estrategiaFrete.CalcularFrete(subtotal, "00000-000");

        var resultado = new CarrinhoViewModel
        {
            Itens = itens,
            Subtotal = subtotal,
            ValorFrete = valorFrete,
            Total = subtotal + valorFrete
        };

        return Task.FromResult(resultado);
    }

    public async Task<bool> ValidarEstoqueAsync(List<ItemCarrinhoViewModel> itens)
    {
        foreach (var item in itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId);
            if (produto == null || produto.Estoque < item.Quantidade)
            {
                return false;
            }
        }
        return true;
    }
}