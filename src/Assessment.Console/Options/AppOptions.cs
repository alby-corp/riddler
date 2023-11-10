using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console.Options
{
    public class AppOptions
    {
        [Required]public string Separator { get; set; } = null!;
        [Required] public string Extension { get; set; } = null!;
        [Required] public string Url { get; set; } = null!;
    }
}
