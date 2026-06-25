for (var i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}


foreach (var i in Enumerable.Range(0, 10))
{
    Console.WriteLine(i);
}

var rangeMultiplied = Enumerable.Range(1,10).Aggregate((acc, n) => acc*n);
Console.WriteLine(rangeMultiplied);
