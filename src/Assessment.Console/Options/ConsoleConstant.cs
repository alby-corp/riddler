namespace Assessment.Console.Options;

using System.ComponentModel.DataAnnotations;

public class ConsoleConstant
{
    [Required, MinLength(7)] public string origin { get; set; } = null!;

    [Required, MaxLength(1)] public string separator { get; set; } = null!;

    [Required, StringLength(4)] public string extension { get; set; } = null!;

}