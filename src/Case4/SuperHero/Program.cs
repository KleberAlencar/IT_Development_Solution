using SuperHero.Models;

var heroes = new SuperHero.Models.SuperHero[]
{
    new Superman("Superman", "Clark Kent", new DateTime(1938, 6, 18), new Random().Next(1, 3)),
    new Batman("Batman", "Bruce Wayne", new DateTime(1939, 4, 7)),
    new GreenArrow("Green Arrow", "Oliver Queen", new DateTime(1941, 9, 19), 5),
    new TheFlash("The Flash", "Barry Allen", new DateTime(1992, 9, 30)),
    new GeneralZod("General Zod", "Dru-Zod", new DateTime(1961, 4, 18), new Random().Next(1, 3)),
};

foreach (var hero in heroes)
{
    if (hero.KryptoniteLevel > hero.MaxKryptoniteLevel)
    {
        Console.WriteLine($"{hero.Name} ({hero.Alias}) - Kryptonita: {hero.KryptoniteLevel} - Nível de Kryptonita excedido!");
        continue;
    }
    
    Console.WriteLine($"{hero.Name} ({hero.Alias}) - Kryptonita: {hero.KryptoniteLevel} - {hero.FlightPowers()}");
}

