//dependency inversion principle handler primært om å håndtere lifetimes. 


public class OrderHandler(OrderRepository repository)
{
    public void ReceiveOrder(Order order)
    {
        //order repositoriet vårt, representere en samling av objekter, som ofte lever som en "high level" dependency. det vil si, det er ofte flere andre deler av programmet vårt som er avhengige av det. 
        //Det bør ikke være denne metoden sin jobb å lage en ny instanse av dette repositoriet, ei heller styre lifetimen til objektet. 

        //Isteden for bør vi gjøre Orderhandleren Dependent på, avhengig av, OrderRepositoriet
        repository.Save(order);
    }
}

public class OrderRepository()
{
    private List<Order> _orders = [];
    public void Save(Order order) => _orders.Add(order);
}

public record Order(Guid Id);