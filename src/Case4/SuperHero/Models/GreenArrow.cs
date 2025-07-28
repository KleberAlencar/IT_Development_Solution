namespace SuperHero.Models;

public class GreenArrow(string name, string alias, DateTime birthDate, int kryptoniteLevel) 
    : SuperHero(name, alias, birthDate, kryptoniteLevel)
{
    public override string FlightPowers()
    {
        return "Maestria excepcional com arco-e-flecha, mas não pode voar.";
    }    
}