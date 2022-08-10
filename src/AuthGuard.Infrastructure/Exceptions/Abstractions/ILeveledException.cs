using Microsoft.Extensions.Logging;

namespace AuthGuard.Infrastructure.Exceptions.Abstractions;

/// <summary>
/// This interface includes LogLevel parameters for ExceptionLevel.
/// For Example;
/// LogLevel.Debug, LogLevel.Information, LogLevel.Warning
/// <see cref="LogLevel"/>
/// </summary>
public interface ILeveledException
{
    LogLevel Level { get; }
}