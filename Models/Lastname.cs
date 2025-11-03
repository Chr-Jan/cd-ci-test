using System;
using System.Text.RegularExpressions;

namespace ValidateTheNameModelBinding.Models
{
    public class Lastname
    {
        public string Value { get; }

        private const int MinLength = 1;
        private const int MaxLength = 50;
        private static readonly Regex AllowedPattern = new Regex(@"^[A-Za-zÆØÅæøå]+(?:[ '-][A-Za-zÆØÅæøå]+)*$", RegexOptions.Compiled);

        public Lastname(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            var trimmed = value.Trim();
            if (trimmed.Length < MinLength || trimmed.Length > MaxLength)
                throw new ArgumentException($"Lastname must be between {MinLength} and {MaxLength} characters.");

            if (!AllowedPattern.IsMatch(trimmed))
                throw new ArgumentException("Lastname contains invalid characters.");

            Value = trimmed;
        }

        public override string ToString() => Value;
    }
}
