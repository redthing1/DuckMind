using Nez;

namespace Ducia.Game.Mind {
    public class MindComponent<T> : Component, IUpdatable where T : MindState, new() {
        public Mind<T> mind { get; }

        public MindComponent(Mind<T> mind) {
            this.mind = mind;
        }

        #region Component Implementation

        public override void OnAddedToEntity() {
            base.OnAddedToEntity();

            mind.initialize();
        }

        public void Update() {
            mind.tick(Time.DeltaTime);
        }

        public override void OnRemovedFromEntity() {
            base.OnRemovedFromEntity();

            mind.destroy();
        }

        #endregion
    }
}