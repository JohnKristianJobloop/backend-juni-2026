var thread1 = new Thread(()=>Count(10));


var thread2 = new Thread(()=>Count(10));

thread1.Start();
thread2.Start();

string threadResult = null;

Thread thread3 = new Thread(() =>
{
    Thread.Sleep(500);
    threadResult = "Posting data from Legacy Thread NameSpace";
});

thread3.Start();
thread3.Join();
Console.WriteLine("Hello, world!");




Console.WriteLine("I'm exiting...");

void Count(int amount)
{
    for (int i = 1; i <= amount; i++)
    {
        Console.WriteLine(i);
    }
}