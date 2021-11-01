namespace TF.Models;

public sealed record Account(string Name)
{
    public override string? ToString() => Name;
}
