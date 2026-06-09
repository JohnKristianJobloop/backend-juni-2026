//la oss si du skal designe en klasse som skal håndtere ordre, og sende de videre til forskjellige undertjenester som må gjøres.


public class OrderHandler(EmailService emailService, Logger logger, DatabaseService dbService)
{
    //Vår ReceiveOrder metode er nå mer lik en controller, som delegerer ansvar videre til de objektene som faktisk har hovedansvaret for hver enkel operasjon. 
    public void ReceiveOrder(Order order)
    {
        emailService.SendEmail(order, "Thanks for ordering");

        logger.LogOrderToFile(order);

        dbService.SaveOrderToDatabase(order);
    }
    /*
    public void ReceiveOrder(Order order)
    {
        //Må behandle orderen vår i tre steg:

        //Vi må sende en bekreftelsesepost. 
        SendEmail(order, "Thanks for ordering!");

        //Logge at vi mottar en ordre til loggesystemet vårt
        LogOrderToFile(order);

        //Vi må lagre ordren vår i databasen permanent. 
        SaveOrderToDatabase(order);

        //Vi ser at i dette eksemplet, bryter vi med single responsibility prinsippet, siden vår class har tre hovedansvar. 

        //Vi ser at classen må endre tilstand i alle tre ansvarsområder.

        //Vi kan rette dette ved å lage underobjekter som har det faktiske ansvaret å håndtere hver operasjon. 

    }

    private void SendEmail(Order order, string mailContent)
    {
        Console.WriteLine($"confirmation sent to {order.Email}: {mailContent}");
    }

    private void LogOrderToFile(Order order)
    {
        File.AppendAllText("order.log.txt", $"Placed the following order: {order.Id}");
    }

    private void SaveOrderToDatabase(Order order)
    {
        Console.WriteLine($"Saved {order.Id} to the database");
    }
    */
}

//Email service inneholder all tilstand som trengs, for å håndtere en epost. 
public class EmailService
{
    public void SendEmail(Order order, string mailContent)
    {
        Console.WriteLine($"confirmation sent to {order.Email}: {mailContent}");
    }
}

//Logger inneholder all tilstand som trengs for å loggføre eventer vi er interesert i. 
public class Logger
{
    public void LogOrderToFile(Order order)
    {
        File.AppendAllText("order.log.txt", $"Placed the following order: {order.Id}");
    }
}

//Database service holder alt av tilstand som trengs for å lagre tilstand til en database. 
public class DatabaseService
{
    public void SaveOrderToDatabase(Order order)
    {
        Console.WriteLine($"Saved {order.Id} to the database");
    }
}

public record Order(Guid Id, string Content, string Email, string UserName);