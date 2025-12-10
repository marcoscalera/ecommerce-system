namespace EcommerceSystem.Patterns.Strategy;

public class FreteExpresso : IEstrategiaFrete
{
    public string Nome => "Expresso";
    public int DiasEntrega => 2;

    public decimal CalcularFrete(decimal valorProdutos, string cep)
    {
        // Expresso é o mais caro: 6% do valor + taxa premium
        return Math.Round(valorProdutos * 0.06m + 40.00m, 2);
    }
}