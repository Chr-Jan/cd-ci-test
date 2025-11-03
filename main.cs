using System;
using System.Text.RegularExpressions;

public class Firstname
{
    public string Value { get; }

    // Konvention: min 1 tegn, max 50 tegn, kun bogstaver, mellemrum tilladt inde i navn (ikke start/slut),
    // ingen tal eller specielle tegn (tilpas efter krav)
    private const int MinLength = 1;
    private const int MaxLength = 50;
    private static readonly Regex AllowedPattern = new Regex(@"^[A-Za-zÆØÅæøå]+(?:[ '-][A-Za-zÆØÅæøå]+)*$",
                                                             RegexOptions.Compiled);

    public Firstname(string value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        var trimmed = value.Trim();
        if (trimmed.Length < MinLength || trimmed.Length > MaxLength)
            throw new ArgumentException($"Firstname must be between {MinLength} and {MaxLength} characters.");
        if (!AllowedPattern.IsMatch(trimmed))
            throw new ArgumentException("Firstname contains invalid characters.");
        Value = trimmed;
    }

    public override string ToString() => Value;
}
