namespace Assessment.Console.Models;

public class Csv
{
    public string? GivenName { get; }
    public string? FamilyName { get; }

    public Csv(string? givenName, string? familyName)
    {
        GivenName = givenName ?? string.Empty;
        FamilyName = familyName ?? string.Empty;
    }
}