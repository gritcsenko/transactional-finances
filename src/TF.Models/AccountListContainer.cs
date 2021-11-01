namespace TF.Models;

public sealed class AccountListContainer : IReadOnlyCollection<AccountList>
{
    private readonly IImmutableSet<AccountList> _lists;

    internal AccountListContainer()
        : this(ImmutableHashSet<AccountList>.Empty)
    {
    }

    internal AccountListContainer(IImmutableSet<AccountList> lists)
        => _lists = lists;

    public static AccountListContainer Empty { get; } = new();

    public int Count => _lists.Count;

    public IEnumerator<AccountList> GetEnumerator()
        => _lists.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public override string? ToString()
        => $"[{string.Join(',', _lists)}]";
}
