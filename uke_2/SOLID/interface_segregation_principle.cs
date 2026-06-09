//Dette interfacet bryter med interface_segregation_principle
//siden det tvinger alle klasser til å garantere for tre uavhengige metoder, som de ikke nødvendigvis tregner å implementere. 

//Disse bør brytes inn i tre separate interfaces, som klassene selv kan plukke og mikse fra som de trenger. 

/* public interface IPrinter
{
    void Print(string text);
    string Scan();
    void Fax(string data, int num);
}*/

//Ved å dele opp interfacen i et sett med mindre interfaces, klarer vi å garantere for at hver class kan ta den delen de kan garantere for. 

public interface IPrintable
{
    void Print(string text);
}

public interface IScannable
{
    string Scan();
}
public interface IFaxable
{
    void Fax(string data, int num);
}

public interface IPrinter: IPrintable, IScannable, IFaxable;

public class SuperPrinter5000: IPrinter
{
    public void Print(string text) => Console.WriteLine(text);

    public string Scan() => "Scanned some data";

    public void Fax(string data, int num) => $"Faxed {data} to {num}";
}

public class SimpleLaserPrinter: IPrintable
{
    public void Print(string text) => Console.WriteLine(text);
}