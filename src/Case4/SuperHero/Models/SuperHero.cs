namespace SuperHero.Models;

public abstract class SuperHero(
    string name, 
    string alias,
    DateTime birthDate, 
    int kryptoniteLevel = 0)
{
    public string Name { get; init; } = name;
    public string Alias { get; init; } = alias;
    public DateTime BirthDate { get; init; } = birthDate;
    public int? KryptoniteLevel { get; init; } = kryptoniteLevel;

    public int MaxKryptoniteLevel { get; } = 4;
    
    public virtual string FlightPowers()
    {
        return KryptoniteLevel < 2 ? "Voando..." : "Não pode voar devido ao nível de Kryptonita.";
    }
}