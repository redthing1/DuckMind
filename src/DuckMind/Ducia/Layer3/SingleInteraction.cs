using Nez;

namespace Ducia {
    public class SingleInteraction<TMind> : PlanInteraction<TMind> {
        public Entity target;

        public SingleInteraction(TMind mind, Entity target, float before = 0) : base(mind, new[] {target}, before) {
            this.target = target;
        }
    }
}