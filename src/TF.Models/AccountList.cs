namespace TF.Models;

public sealed class AccountList : IReadOnlyCollection<Account>, IEquatable<AccountList>
{
    private readonly IImmutableSet<Account> _accounts;

    internal AccountList(string name)
        : this(name, ImmutableHashSet<Account>.Empty)
    { 
    }

    internal AccountList(string name, IImmutableSet<Account> accounts)
        => (Name, _accounts) = (name, accounts);

    public string Name { get; }

    public int Count => _accounts.Count;

    public static AccountList Empty(string name)
        => new(name);

    public AccountList Add(Account account)
    {
        var newset = _accounts.Add(account);
        return _accounts.Equals(newset)
            ? this
            : new(Name, newset);
    }

    public AccountList AddRange(IEnumerable<Account> accounts)
        => accounts.Aggregate(this, (list, account) => list.Add(account));

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
        hash.Add(_accounts.Count);
        foreach (var account in _accounts)
        {
            hash.Add(account);
        }
        return hash.ToHashCode();
    }

    public override string? ToString()
        => $"{Name}: [{string.Join(',', _accounts)}]";
}
