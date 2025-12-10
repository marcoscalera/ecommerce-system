// Patterns/Strategy/PagamentoCartao.cs
public class PagamentoCartao : IEstrategiaPagamento
{
    public string Nome => "Cartão de Crédito";

    public decimal ProcessarPagamento(decimal valor)
    {
        // Cartão tem taxa de 3%
        decimal taxa = valor * 0.03m;
        return Math.Round(valor + taxa, 2);
    }

    public string ObterInformacoes()
    {
        return "Parcelamento em até 12x. Taxa de 3% aplicada.";
    }
}