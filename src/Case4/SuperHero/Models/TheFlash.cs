namespace SuperHero.Models;

public class TheFlash(string name, string alias, DateTime birthDate, int kryptoniteLevel = 0) 
    : SuperHero(name, alias, birthDate, kryptoniteLevel)
{
    public override string FlightPowers()
    {
        return "Utiliza o poder de aceleração para 'correr no ar'.";
    }   
}