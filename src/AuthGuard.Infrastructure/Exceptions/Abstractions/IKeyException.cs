namespace AuthGuard.Infrastructure.Exceptions.Abstractions;

/// <summary>
/// Key Exception
/// This interface includes necessary parameter for type of Key exceptions.
/// </summary>
public interface IKeyException
{
    string Key { get; }

    int Code { get; }

    string Instance { get; }

    object[] Params { get; }
}