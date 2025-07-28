namespace SuperHero.Models;

public class Batman(string name, string alias, DateTime birthDate, int kryptoniteLevel = 0) 
    : SuperHero(name, alias, birthDate, kryptoniteLevel)
{
    public override string FlightPowers()
    {
        return "Possui habilidades excepcionais em combate, mas não pode voar.";
    }    
}