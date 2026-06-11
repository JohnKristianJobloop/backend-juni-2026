// See https://aka.ms/new-console-template for more information
using core.Services;

Console.WriteLine("Hello, World!");

var input = "Bravely Bold Sir Robin";
var inputSum = (uint)input.Sum(c => c);
var random = new RandyRandom(input);

var next = random.NextInt;
(var x, var y) = random.GetSeedValues;

Console.WriteLine(next);

var fl = 0.9999999999999999f;

Console.WriteLine($"Original Value: {inputSum}, generated seed: {(uint)x}, random datetime seed: {y}");

Console.WriteLine(fl);