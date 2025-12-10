namespace EcommerceSystem.Patterns.Decorator;

public class GarantiaEstendida : ProdutoDecorator
{
    public GarantiaEstendida(IProdutoComponent produto) : base(produto) { }

    public override string ObterDescricao()
    {
        return $"{_produto.ObterDescricao()} + Garantia Estendida (12 meses)";
    }

    public override decimal ObterPreco()
    {
        // Garantia custa 10% do valor do produto
        decimal custoGarantia = _produto.ObterPreco() * 0.10m;
        return _produto.ObterPreco() + custoGarantia;
    }
}