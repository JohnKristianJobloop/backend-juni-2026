namespace core.Models;

internal class Seed
{
    // en unsigned integer (uint) er en datatype som ikke kan representere negative verdier. Den bruker alle 32 bits for å representer en hel integer. 
    internal ulong X {get; private set;}
    internal ulong Y {get; private set;}

    internal Seed()
    {
        X = (ulong)DateTime.Now.Microsecond;
        Y = (ulong)DateTime.Now.Microsecond;
    }

    internal Seed(int value)
    {
        X = (ulong) value;
        Y = (ulong) DateTime.Now.Microsecond;
    }

    internal Seed(string value)
    {
        X = (ulong) value.Sum(c => c);
        Y = (ulong) DateTime.Now.Microsecond;
    }

    internal Seed(ulong x, ulong y)
    {
        X = x;
        Y = y;
    }

    internal void Deconstruct(out ulong x, out ulong y)
    {
        x = X;
        y = Y;
    }
}