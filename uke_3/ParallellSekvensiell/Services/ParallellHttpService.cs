using System.Diagnostics;

namespace ParallellSekvensiell.Services
{
    public class ParallellHttpService(HttpClient client) : BaseService(client)
    {
        public async Task ParallellGetAsync(IEnumerable<string> endpoints)
        {
            var stopwatch = Stopwatch.StartNew();

            List<Task> tasks = [.. endpoints.Select(GetFromEndpointAsync)];

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Parallell operation took {stopwatch.ElapsedMilliseconds}ms to complete");
        }
    }
}