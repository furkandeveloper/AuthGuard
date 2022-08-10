using System.Net;

namespace AuthGuard.Infrastructure.Exceptions.Abstractions;

/// <summary>
/// This interface includes StatusCode parameter for Exception Handler.
/// For Example;
/// StatusCode.Forbidden, StatusCode.NotFound
/// <see cref="HttpStatusCode"/>
/// </summary>
public interface IStatusCodeException
{
    HttpStatusCode StatusCode { get; }
}