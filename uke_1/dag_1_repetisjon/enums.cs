
/// <summary>
/// Red = 0000
/// Blue = 0001
/// 
/// bitwise | (or) er å se om enten eller har 1 i bitposisjonen sin. 
/// 
/// 
/// Red 0000
/// blue 0001
/// 
/// blue 0001
/// </summary>


var fileRights = Rights.Read | Rights.Write;

FileRightsValidator.ValidateRights(fileRights);

enum Rights
{
    None = 0, // 0000
    Read = 1 << 0, // 0001
    Write = 1 << 1, // 0010
    Execute = 1 << 2 // 0100
}

static class FileRightsValidator
{
    public static void ValidateRights(Rights rights)
    {
        //Vi ser på rights, og gjør en bitwise & for å finne ut om read flagget eksisterer i rights. 
        if ((rights & Rights.Read) == Rights.Read)
        {
            Console.WriteLine("You can read this file");
        }
        if ((rights & Rights.Write) == Rights.Write)
        {
            Console.WriteLine("You can write to the file");
        }
        if ((rights & Rights.Execute) == Rights.Execute)
        {
            Console.WriteLine("You can execute this file");
        }
    }
}
