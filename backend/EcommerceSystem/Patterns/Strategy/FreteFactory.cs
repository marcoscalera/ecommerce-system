namespace EcommerceSystem.Patterns.Strategy;

public static class FreteFactory
{
    public static IEstrategiaFrete CriarEstrategia(string tipoFrete)
    {
        return tipoFrete.ToUpper() switch
        {
            "PAC" => new FretePAC(),
            "SEDEX" => new FreteSEDEX(),
            "EXPRESSO" => new FreteExpresso(),
            _ => new FretePAC()
        };
    }
}