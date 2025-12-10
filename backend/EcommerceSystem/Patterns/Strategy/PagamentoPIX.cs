// Patterns/Strategy/PagamentoPIX.cs
public class PagamentoPIX : IEstrategiaPagamento
{
    public string Nome => "PIX";

    public decimal ProcessarPagamento(decimal valor)
    {
        // PIX tem desconto de 10%
        decimal desconto = valor * 0.10m;
        return Math.Round(valor - desconto, 2);
    }

    public string ObterInformacoes()
    {
        return "10% de desconto à vista. Pagamento instantâneo.";
    }
}
