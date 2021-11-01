namespace TF.Models;

public sealed class AccountListContainer : IReadOnlyCollection<AccountList>
{
    private readonly ImmutableHashSet<AccountList> _lists = ImmutableHashSet<AccountList>.Empty;

    public AccountListContainer()
    {
    }

    public int Count => _lists.Count;

    public IEnumerator<AccountList> GetEnumerator()
        => _lists.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public override string? ToString()
        => $"[{string.Join(',', _lists)}]";
}
