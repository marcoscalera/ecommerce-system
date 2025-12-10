namespace EcommerceSystem.Patterns.Decorator;

public class ProdutoDecoratorService
{
    public IProdutoComponent AplicarExtras(string nomeProduto, decimal precoProduto, bool adicionarGarantia, bool adicionarEmbrulho)
    {
        IProdutoComponent produto = new ProdutoBase(nomeProduto, precoProduto);

        if (adicionarGarantia)
        {
            produto = new GarantiaEstendida(produto);
        }

        if (adicionarEmbrulho)
        {
            produto = new EmbrulhoPresente(produto);
        }

        return produto;
    }

    public decimal CalcularPrecoComExtras(decimal precoBase, bool adicionarGarantia, bool adicionarEmbrulho)
    {
        decimal precoFinal = precoBase;

        if (adicionarGarantia)
        {
            precoFinal += precoBase * 0.10m; // 10% para garantia
        }

        if (adicionarEmbrulho)
        {
            precoFinal += 15.00m; // R$ 15 para embrulho
        }

        return Math.Round(precoFinal, 2);
    }

    public List<string> ObterExtrasAplicados(bool adicionarGarantia, bool adicionarEmbrulho)
    {
        var extras = new List<string>();

        if (adicionarGarantia)
        {
            extras.Add("Garantia Estendida (12 meses) - +10%");
        }

        if (adicionarEmbrulho)
        {
            extras.Add("Embrulho para Presente - +R$ 15,00");
        }

        return extras;
    }
}