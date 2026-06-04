namespace core.Models;

/// <summary>
/// Represents the outcome of an operation that can either succeed or fail.
/// Use this instead of throwing exceptions for expected failure conditions,
/// such as invalid user input or failed lookups. Callers are forced to handle
/// both cases explicitly via pattern matching.
/// </summary>
public interface IResult;

/// <summary>
/// Represents a successful outcome carrying a result value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the successful result.</typeparam>
/// <param name="Value">The result of the successful operation.</param>
public record Success<T>(T Value) : IResult;

/// <summary>
/// Represents a failed outcome carrying a human-readable description of what went wrong.
/// </summary>
/// <param name="Message">A description of the failure, suitable for display to the caller.</param>
public record Error(string Message) : IResult;