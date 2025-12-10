// Patterns/Strategy/PagamentoBoleto.cs
public class PagamentoBoleto : IEstrategiaPagamento
{
    public string Nome => "Boleto Bancário";

    public decimal ProcessarPagamento(decimal valor)
    {
        // Boleto tem desconto de 5%
        decimal desconto = valor * 0.05m;
        return Math.Round(valor - desconto, 2);
    }

    public string ObterInformacoes()
    {
        return "5% de desconto à vista. Vencimento em 3 dias úteis.";
    }
}