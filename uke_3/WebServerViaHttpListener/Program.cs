// See https://aka.ms/new-console-template for more information
using WebServerViaHttpListener.Models;

Console.WriteLine("Hello, World!");


var server = new WebServer("http://localhost:6969/");

try
{
   server.StartAsync();
   Console.WriteLine("Press any key to stop the server...");
   Console.ReadLine(); 
}
finally
{
    server.Stop();
}