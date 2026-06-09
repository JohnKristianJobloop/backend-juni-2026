public class Bird
{
    
}

public class BirdWithFlight : Bird
{
    public void Fly() => Console.WriteLine("Bird is flying!");
}

public class Eagle : BirdWithFlight
{
    public override void Fly() => Console.WriteLine("Eagle flying above the clouds");
}

public class Penguin : Bird
{
    
}

//Denne implementasjonen av fugler bryter med Liskov Substitution Principle, siden Penguins bryter med forventet oppførsel av fugle klassen vår. 
//Prøver vi å få en Penguin til å fly, krasher programmet vårt. 

//Vi kan løse dette ved å se at vi bør ha en ekstra sub klasse her, siden ikke alle fugler kan fly. 

public static class BirdFlyer
{
    public static void Run()
    {
        var eagle = new Eagle();
        var penguin = new Penguin();
        MakeBirdsFly(eagle);
        MakeBirdsFly(penguin);
    }
    public static void MakeBirdsFly(BirdWithFlight bird) => bird.Fly();
}