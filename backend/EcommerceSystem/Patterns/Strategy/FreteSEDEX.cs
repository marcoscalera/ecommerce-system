namespace EcommerceSystem.Patterns.Strategy;

public class FreteSEDEX : IEstrategiaFrete
{
    public string Nome => "SEDEX";
    public int DiasEntrega => 5;

    public decimal CalcularFrete(decimal valorProdutos, string cep)
    {
        // SEDEX é mais caro: 4% do valor + taxa maior
        return Math.Round(valorProdutos * 0.04m + 25.00m, 2);
    }
}