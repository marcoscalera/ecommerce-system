// ViewModels/ProdutoViewModel.cs
namespace EcommerceSystem.ViewModels;

public class ProdutoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string ImagemUrl { get; set; } = string.Empty;
    public bool EmEstoque => Estoque > 0;
}