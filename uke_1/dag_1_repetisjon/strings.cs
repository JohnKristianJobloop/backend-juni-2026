string myName = "John";

int number1 = 1;
int number2 = 2;

string interpolatedString = $"tall 1: {number1}, tall 2: {number2}";
string formattedString = string.Format("Hello, {0}",myName);

string secondFormattedString = string.Format("Tall 2: {1}, tall 1: {0}", number1, number2);

Console.WriteLine(interpolatedString);
// Console.WriteLine(formattedString);
// Console.WriteLine(secondFormattedString);

string introText = """
Hei!

Velkommen til C# intermediate.
------------------------------

Her vil du lære følgende:
    1. Kodestiler og kodestandarder
    2. Designpatterns rundt objektorientert koding.
    3. Bli komfortabel med å jobbe med APIer.
Dette er en string literal, den fanger opp spesialkarakterer som \n (new line) \t (tab) og  (space)
du skriver, og legger de inn for deg i teksten automatisk, uten at du trenger å skrive dem selv. 
""";

Console.WriteLine(introText);

char firstLetter = introText[0];


