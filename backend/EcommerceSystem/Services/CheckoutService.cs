using EcommerceSystem.Models;
using EcommerceSystem.Repositories;
using EcommerceSystem.Patterns.Strategy;
using EcommerceSystem.Patterns.Decorator;

namespace EcommerceSystem.Services;

public class CheckoutService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly ProdutoDecoratorService _decoratorService;

    public CheckoutService(
        IPedidoRepository pedidoRepository, 
        IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;
        _decoratorService = new ProdutoDecoratorService();
    }

    public async Task<Pedido> ProcessarCheckoutAsync(CheckoutRequest request)
    {
        foreach (var item in request.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId);
            if (produto == null || produto.Estoque < item.Quantidade)
            {
                throw new InvalidOperationException($"Produto {item.Nome} sem estoque suficiente");
            }
        }

        decimal subtotal = request.Itens.Sum(i => i.Subtotal);
        
        var estrategiaFrete = FreteFactory.CriarEstrategia(request.TipoFrete);
        decimal valorFrete = estrategiaFrete.CalcularFrete(subtotal, request.CEP);

        decimal valorExtras = 0;
        if (request.AdicionarGarantia || request.AdicionarEmbrulho)
        {
            foreach (var item in request.Itens)
            {
                decimal precoComExtras = _decoratorService.CalcularPrecoComExtras(
                    item.Preco * item.Quantidade,
                    request.AdicionarGarantia,
                    request.AdicionarEmbrulho
                );
                valorExtras += precoComExtras - (item.Preco * item.Quantidade);
            }
        }

        decimal valorTotal = subtotal + valorFrete + valorExtras;

        var estrategiaPagamento = PagamentoFactory.CriarEstrategia(request.MetodoPagamento);
        decimal valorFinal = estrategiaPagamento.ProcessarPagamento(valorTotal);

        var pedido = new Pedido
        {
            DataPedido = DateTime.Now,
            ValorTotal = valorFinal,
            Status = "Confirmado",
            MetodoPagamento = request.MetodoPagamento,
            TipoFrete = request.TipoFrete,
            ValorFrete = valorFrete,
            Itens = request.Itens.Select(i => new ItemPedido
            {
                ProdutoId = i.ProdutoId,
                NomeProduto = i.Nome,
                PrecoUnitario = i.Preco,
                Quantidade = i.Quantidade,
                Subtotal = i.Subtotal
            }).ToList()
        };

        foreach (var item in request.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId);
            if (produto != null)
            {
                produto.Estoque -= item.Quantidade;
                await _produtoRepository.UpdateAsync(produto);
            }
        }

        return await _pedidoRepository.AddAsync(pedido);
    }

    public async Task<List<Pedido>> ObterPedidosAsync()
    {
        return await _pedidoRepository.GetAllAsync();
    }
}