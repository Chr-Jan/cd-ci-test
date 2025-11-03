using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ValidateTheNameModelBinding.Models
{
    public class PersonDTO
    {
        [NotNull]
        public string? Firstname { get; set; }
        [NotNull]
        public string? Lastname { get; set; }
    }
}
