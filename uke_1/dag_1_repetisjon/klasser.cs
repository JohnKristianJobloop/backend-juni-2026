
//APIet til Person klassen, er tilnærmet ikke eksisterende. Vi kan lage objekter, sette data til objekter, that's it. 

var person = new Person().WithName("John").WithAge(34).WithAdress("Oslo");

Console.WriteLine(person.Name);

person.Name = "John K";

//Basic representasjon av en Person class, som kun har datafelt i seg. 
//class Person
//{
//    public string Name;
//    public int Age;
//    public string Adress;
//}

//Her bruker vi litt mer komplekse getters og setters for å finjustere APIet til hvert felt. 

//class Person
//{
//    public string Name
//    {
//        get; set
//        {
//            if (string.IsNullOrWhiteSpace(value)) throw ArgumentNullException("Invalid name");
//            field = value;
//        }
//    }
//
//    private int _age;
//    public int Age {
//        get => _age;
//        set => _age = value;
//    }
//    public string Adress{get;set;}
//}


//class Person(string name, int age, string adress)
//{
//    public string Name{get;set;} = name;
//    public int Age{get;set;} = age;
//    public string Adress{get;set;} = adress;
//}

//class Person
//{
//    public string Name {get;set;}
//    public int Age{get;set;}
//    public string Adress {get;set;}
//
//    public Person(string name, int age, string adress){
//        Name = name;
//        Age = age;
//        Adress = adress;
//    }
//}

class Person
{
    public string Name{get; set;}
    public int Age {get; set;}
    public string Adress {get; set;}
}

static class PersonExtender
{
    public static Person WithName(this Person? person, string name)
    {
        person ??= new Person();
        person.Name = name;
        return person;   
    } 

    public static Person WithAge(this Person person, int age)
    {
        person ??= new Person();
        person.Age = age;
        return person;
    }

    public static Person WithAdress(this Person person, string adress)
    {
        person ??= new Person();
        person.Adress = adress;
        return person;
    }
}
