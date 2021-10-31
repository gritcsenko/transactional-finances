namespace TF.Models;

public sealed class AccountList : IReadOnlyCollection<Account>, IEquatable<AccountList>
{
    private readonly ImmutableHashSet<Account> _accounts = ImmutableHashSet<Account>.Empty;

    public AccountList(string name) 
        => Name = name;

    public string Name { get; init; }

    public int Count => _accounts.Count;

    public IEnumerator<Account> GetEnumerator()
        => _accounts.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();

    public bool Equals(AccountList? other)
        => Name.Equals(other?.Name)
        && _accounts.SetEquals(other._accounts);

    public override bool Equals(object? obj) 
        => Equals(obj as AccountList);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Name);
        foreach (var account in _accounts)
        {
            hash.Add(account);
        }
        return hash.ToHashCode();
    }

    public override string? ToString()
        => $"{Name}: [{string.Join(',', _accounts)}]";
}
