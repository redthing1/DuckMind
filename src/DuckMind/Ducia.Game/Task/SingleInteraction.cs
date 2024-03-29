using Nez;

namespace Ducia.Game.Task {
    public class SingleInteraction<TMind> : PlanInteraction<TMind> where TMind : IMind {
        public Entity target;

        public SingleInteraction(TMind mind, Entity target, float before = 0) : base(mind, new[] {target}, before) {
            this.target = target;
        }
    }
}