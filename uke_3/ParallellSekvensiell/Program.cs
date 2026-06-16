using ParallellSekvensiell.Services;

var client = new HttpClient();

var seqService = new SequentialHttpService(client);

var paraService = new ParallellHttpService(client);

List<string> endpoints = [
    "https://icanhazdadjoke.com/",
    "https://official-joke-api.appspot.com/random_joke",
    "https://api.chucknorris.io/jokes/random"
];

await seqService.SequentialGetAsync(endpoints);

await paraService.ParallellGetAsync(endpoints);