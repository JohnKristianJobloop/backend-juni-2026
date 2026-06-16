int[] numberArray = [1,2,3,4,5];
List<int> numberList = [1,2,3,4,5];
for (int i = 0; i < numberArray.Length; i++)
{
    var number = numberArray[i];
    Console.WriteLine(number);
}
for (int i = 69; i > 10; i -= 4)
{
    Console.WriteLine(i);
}

foreach (int number in numberList) Console.WriteLine(number);


numberArray = [.. numberArray, 6];
numberList.Add(6);

foreach(var number in numberArray) Console.WriteLine(number);
foreach(var number in numberList) Console.WriteLine(number);

//Litt repetisjon om funksjoner. 
Func<int, bool> predicate = (x) => x % 2 == 1;
Func<int, int> transformer = (x) => x * 2;
var multipliedList = numberList.Where(num => predicate(num)).Select(num => transformer(num));