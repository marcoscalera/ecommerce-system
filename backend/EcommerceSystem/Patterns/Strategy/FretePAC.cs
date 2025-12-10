namespace EcommerceSystem.Patterns.Strategy;

public class FretePAC : IEstrategiaFrete
{
    public string Nome => "PAC";
    public int DiasEntrega => 10;

    public decimal CalcularFrete(decimal valorProdutos, string cep)
    {
        // Lógica simplificada: 2% do valor + taxa base
        return Math.Round(valorProdutos * 0.02m + 15.00m, 2);
    }
}