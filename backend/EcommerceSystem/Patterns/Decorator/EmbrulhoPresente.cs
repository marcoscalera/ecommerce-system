namespace EcommerceSystem.Patterns.Decorator;

public class EmbrulhoPresente : ProdutoDecorator
{
    public EmbrulhoPresente(IProdutoComponent produto) : base(produto) { }

    public override string ObterDescricao()
    {
        return $"{_produto.ObterDescricao()} + Embrulho para Presente";
    }

    public override decimal ObterPreco()
    {
        return _produto.ObterPreco() + 15.00m;
    }
}