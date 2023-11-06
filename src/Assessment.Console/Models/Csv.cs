namespace Assessment.Console.Models;

public record Csv(string? GivenName, string? FamilyName)
{
    public string? GivenName { get; init; } = GivenName ?? string.Empty;
    public string? FamilyName { get; init; } = FamilyName ?? string.Empty;
}