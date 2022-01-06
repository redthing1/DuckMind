using System;

namespace Ducia; 

/// <summary>
///     indicates that the mind is in an invalid state
/// </summary>
public class InvalidMindStateException : Exception {
    public InvalidMindStateException(string message) : base(message) { }
}