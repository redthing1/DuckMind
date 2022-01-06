namespace Ducia.Utils; 

/// <summary>
///     Represents a cached object for the AI.
/// </summary>
/// <typeparam name="T"></typeparam>
public readonly struct Cache<T> {
    /// <summary>
    ///     The cached value to store
    /// </summary>
    public readonly T val;

    /// <summary>
    ///     A key indicating the state of the cache
    /// </summary>
    public readonly object key;

    public Cache(T value, object key) {
        val = value;
        this.key = key;
    }

    /// <summary>
    ///     Compares a value to the cache key to check if the cached value is still valid
    /// </summary>
    /// <param name="check"></param>
    /// <returns></returns>
    public bool dirty(object check) {
        return check != key;
    }
}