using System.Net.Http.Headers;

namespace ParallellSekvensiell.Services;

public class BaseService(HttpClient client)
{
    // Når vi tar inn et object i primærkonstructoren, 
    // trenger vi ikke lage egne felt for den. 
    // Hvis ikke vi ABSOLUTT MÅ styre access osv. 
    // private HttpClient _client = client;

    public async Task GetFromEndpointAsync(string endpoint)
    {
        try
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received {content}\n from: {endpoint}");
        }
        catch (HttpRequestException httpEx)
        {
           Console.WriteLine($"Caught an http exception: {httpEx.Message}"); 
        }
        catch(InvalidOperationException invEx)
        {
            Console.WriteLine($"Caught an invalid operation exception: {invEx.Message}"); 
        }
        catch (OperationCanceledException opCEx)
        {
            Console.WriteLine($"Caught an operation Cancelled exception: {opCEx.Message}"); 
        }
        catch (UriFormatException uriEx)
        {
            Console.WriteLine($"Caught an uri format exception: {uriEx.Message}"); 
        }
    }
}