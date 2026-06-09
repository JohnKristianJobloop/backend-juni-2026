
public class CustomerDiscountService
{
    //Dette eksemplet bryter med Open Closed principle, siden CustomerDiscountService er tightly coupled med CustomerType enumen. 
    //Hvis vi endrer enumen vår, må vi også huske å endre denne classen. 
    /*public decimal GetDiscountedPriceForCustomerType(CustomerType type, decimal originalAmount)
    {
        return type switch
        {
            CustomerType.Regular => originalAmount * 0.95m,
            CustomerType.Vip => originalAmount * 0.80m,
            CustomerType.SuperVip => originalAmount * 0.75m,
            _ => throw new NotSupportedException("Unknown customer type")
        };
    }*/

    //Vi kan endre på måten vi implementerer både customer type på, og måten denne metoden behandler customer type, slik at de er mindre avhengig av hverandre.
     public decimal GetDiscountedPriceForCustomerType(CustomerType type, decimal originalAmount) => originalAmount * (decimal)type;
}
public enum CustomerType {Regular = 0.95m, Vip = 0.80m, SuperVip = 0.75m, SuperDuperVip = 0.60m}


//Annet eksempel, vi har en shape, og en klasse som har som ansvar å regne ut arealet til en shape. 


//for å løse dette, kan vi enten ha en grunnlegende Shape klasse, som alt kan inherite fra, eller en felles kontrakt alle shapes kan oppfylle. 

public class Shape
{
    public virtual double CalculateArea();
}
public class Rectangle: Shape
{
    public double Width{get;set;}
    public double Height {get;set;}
    public override double CalculateArea() => Width * Height;
}
public class Circle: Shape
{
    public double Radius {get;set;}
    public override double CalculateArea() => Math.PI * Radius * Radius;
}
//Hva skjer her, når vi legger til en annen form?
public class AreaCalculator
{
    /*public double CalculateAreaOfRectangle(Rectangle rectangle)
    {
        return rectangle.Width * rectangle.Height;
    }*/

    public double CalculateArea(Shape shape) => shape.CalculateArea();

}