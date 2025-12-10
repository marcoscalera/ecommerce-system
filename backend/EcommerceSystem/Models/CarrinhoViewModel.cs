// ViewModels/CarrinhoViewModel.cs
public class CarrinhoViewModel
{
    public List<ItemCarrinhoViewModel> Itens { get; set; } = new();
    public decimal Subtotal { get; set; }
    public decimal ValorFrete { get; set; }
    public decimal Total { get; set; }
}

public class ItemCarrinhoViewModel
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public decimal Subtotal { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
}