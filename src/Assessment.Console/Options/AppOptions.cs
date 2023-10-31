namespace Assessment.Console.Options;

using System.ComponentModel.DataAnnotations;

public class AppOptions
{
    [Required, MinLength(10)] public string BaseUrl { get; set; } = null!;
    [Required, MinLength(1)] public string Separator { get; set; } = null!;
    [Required, MinLength(3)] public string Extension { get; set; } = null!;
    [Required, MinLength(10)] public string DateFormat { get; set; } = null!;
}
