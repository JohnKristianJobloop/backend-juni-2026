var client = new HttpClient();

var result = await client.GetAsync("https://www.nrk.no");

await File.AppendAllTextAsync("./result.html", await result.Content.ReadAsStringAsync());