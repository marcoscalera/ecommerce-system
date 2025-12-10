namespace EcommerceSystem.Patterns.Decorator;

public class ProdutoBase : IProdutoComponent
{
    private readonly string _nome;
    private readonly decimal _preco;

    public ProdutoBase(string nome, decimal preco)
    {
        _nome = nome;
        _preco = preco;
    }

    public string ObterDescricao()
    {
        return _nome;
    }

    public decimal ObterPreco()
    {
        return _preco;
    }
}