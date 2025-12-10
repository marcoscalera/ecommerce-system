// Patterns/Strategy/PagamentoFactory.cs
public static class PagamentoFactory
{
    public static IEstrategiaPagamento CriarEstrategia(string metodoPagamento)
    {
        return metodoPagamento.ToUpper() switch
        {
            "CARTAO" => new PagamentoCartao(),
            "BOLETO" => new PagamentoBoleto(),
            "PIX" => new PagamentoPIX(),
            _ => new PagamentoCartao()
        };
    }
}