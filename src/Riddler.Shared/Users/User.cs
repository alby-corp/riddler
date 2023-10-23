namespace Riddler.Shared.Users;

using System.Text.Json.Serialization;

public class User
{
    [JsonPropertyName("mail")] public string? Email { get; set; }
    [JsonPropertyName("given-name")] public string? GivenName { get; set; }
    [JsonPropertyName("family-name")] public string? FamilyName { get; set; }
}