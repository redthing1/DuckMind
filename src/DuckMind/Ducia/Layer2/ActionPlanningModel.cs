using Activ.GOAP;

namespace Ducia.Layer2 {
    public abstract class ActionPlanningModel<T> : Agent, Clonable<T> where T : new() {
        public float cost { get; set; }
        private Option[]? cachedOpts; // caching reduces array alloc overheads
        public Option[] Options() => cachedOpts ??= ActionOptions;
        public abstract Option[] ActionOptions { get; }
        public T Allocate() => new T();

        public abstract T Clone(T b);
    }
}