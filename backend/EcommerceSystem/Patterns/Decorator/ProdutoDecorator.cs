namespace EcommerceSystem.Patterns.Decorator;

public abstract class ProdutoDecorator : IProdutoComponent
{
    protected IProdutoComponent _produto;

    protected ProdutoDecorator(IProdutoComponent produto)
    {
        _produto = produto;
    }

    public virtual string ObterDescricao()
    {
        return _produto.ObterDescricao();
    }

    public virtual decimal ObterPreco()
    {
        return _produto.ObterPreco();
    }
}