using CountingOnThreadsAndTask.Models;

namespace CountingOnThreadsAndTask.Services;


public static class TaskCounterService
{
    public static List<Task<bool>> RunThreads(IEnumerable<Counter> counters)
    {
        List<Task<bool>> tasks = [];

        foreach(var counter in counters)
        {
            tasks.Add(CountAsync(counter));
        }

        return tasks;
    }

    private static async Task<bool> CountAsync(Counter counter)
    {
        Console.WriteLine($"Counter {counter.Name} started counting on Task...");

        for(var i = 1; i <= counter.MaxVal; i++)
        {
            await Task.Delay(counter.Delay);
            Console.WriteLine($"Counted {i} times on {counter.Name}");
        }
        Console.WriteLine($"Counter {counter.Name} is complete");
        return true;
    }
}