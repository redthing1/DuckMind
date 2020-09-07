using System;
using Activ.GOAP;

namespace Ducia {
    public abstract class ActionPlanningModel<T> : Agent, Clonable<T>, IEquatable<T> where T : new() {
        protected abstract Option[] ActionOptions { get; }

        #region Object Methods
        public T Allocate() => new T();
        public abstract T Clone(T b);
        public abstract bool Equals(T b);
        #endregion

        // - internal caching of options
        private Option[]? cachedOpts; // caching reduces array alloc overheads
        public Option[] Options() => cachedOpts ??= ActionOptions;
    }
}