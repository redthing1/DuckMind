namespace DuckMind.Utils {
    /// <summary>
    /// Represents a cached object for the AI.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CacheThing<T> {
        /// <summary>
        /// The cached value to store
        /// </summary>
        public T val;
        /// <summary>
        /// A key indicating the state of the cache
        /// </summary>
        public object key;

        /// <summary>
        /// Compares a value to the cache key to check if the cached value is still valid
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public bool dirty(object check) => check != key;
    }
}