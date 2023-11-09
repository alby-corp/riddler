namespace Assessment.Console.Models;

public class Csv
{
    internal Csv(string? givenName , string? familyName)
    {
        GivenName = givenName;
        FamilyName = familyName;
    }

    public string? GivenName { get;  }
    public string? FamilyName { get;  }
}