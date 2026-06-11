using core.Models;

namespace core.Services;

public class RandyRandom
{
    private Seed _seed = new();

    public RandyRandom(int seedVal)
    {
        _seed = new(seedVal);
    }

    public RandyRandom(string seedVal)
    {
        _seed = new(seedVal);
    }

    private ulong CreateRandomInteger()
    {
        //Her kaller vi automatisk på deconstruct metoden vår. Dette er det samme som om vi hadde gjort følgende:
        //uint x = 0;
        //uint y = 0;
        //_seed.Deconstruct(out x, out y);
        (var x, var y) = _seed;
        //Her gjør vi to bitwise operasjoner, det første vi gjør er å skifte bits 23 plasser til venstre. 

        //given 0x0001 << 1 = 0x0010
        //given 0x1000 << 1 = 0x0000

        //Så gjør vi en xor

        //given 0x0100 ^ 0x0101 = 0x0001

        //Nedenfor kombinerer vi begge. 
        //Vi tar først og leftskifter x 23 plasser. x << 23.
        //Vi tar så å xor (exclusive or) x med resultatet av leftskift. 
        x ^= x << 25; 

        x ^= x >> 19;


        x ^= y;

        _seed = new(y, x);
        return x;
    }

    private (ulong x, ulong y) Reverse()
    {
        (var y, var x) = _seed;
    
        x ^= y;
        x ^= x >> 19;
        x ^= x << 25;
        return (x, y);
    }
    public ulong NextInt => CreateRandomInteger();

    public (ulong x, ulong y) GetSeedValues => Reverse();
}