using System.Net.Sockets;
using System.Text;



//Her setter vi opp en lytter, som lytter etter tcp requests på systemets ip adresse, og socket 5050.
var listener = new TcpListener(System.Net.IPAddress.Loopback, 5050);
listener.Start();

//Vi prøver å hente en client, og en nettverkstream til clienten fra en tilkobling.
using var client = await listener.AcceptTcpClientAsync();
using var stream = client.GetStream();


//Vi setter opp en buffer vi kan legge data fra streamen inn i. 
var buffer = new byte[8192];

//Vi leser så streamen inn i bufferen, readBytes er antal bytes lest inn i buffer. 
var readBytes = await stream.ReadAsync(buffer, 0, buffer.Length);

//Vi tar da bytes fra buffer som representerer dataen og prøver å parse det til en string. 
var rawRequest = Encoding.UTF8.GetString(buffer, 0, readBytes);


//Vi setter så opp en response vi kan sende tilbake til klienten
//Vi passer på å følge http standarden så godt vi kan. 
string[] responses = ["Kilroy was here.", "Stop snooping!"];

var rand = Random.Shared.Next() % responses.Length;

var responseMessage = responses[rand];

var response = $"""
HTTP/1.1 200 OK
Content-Type: text/plain
Content-Length: {Encoding.UTF8.GetByteCount(responseMessage)}

{responseMessage}
""";

//Vi konverterer så requesten til bytes, før vi streamer den tilbake til klienten
//Gjennom samme nettverkstrøm. 
var responseAsBytes = Encoding.UTF8.GetBytes(response);

await stream.WriteAsync(responseAsBytes);
Console.WriteLine($"Størrelse på request: {readBytes}");
Console.WriteLine(rawRequest);
