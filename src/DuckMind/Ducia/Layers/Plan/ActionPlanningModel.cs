using System;
using Activ.GOAP;

namespace Ducia; 

/// <summary>
///     represents a base action planning model for an agent
///     this will be fed into a GOAP planner
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ActionPlanningModel<T> : Agent, Clonable<T>, IEquatable<T> where T : new() {
    // - internal caching of options
    private Option[]? cachedOpts; // caching reduces array alloc overheads
    protected abstract Option[] ActionOptions { get; }

    public Option[] Options() {
        return cachedOpts ??= ActionOptions;
    }

    #region Object Methods

    public T Allocate() {
        return new T();
    }

    public abstract T Clone(T b);
    public abstract bool Equals(T b);

    #endregion
}