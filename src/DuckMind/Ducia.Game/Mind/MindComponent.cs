using Nez;

namespace Ducia.Game.Mind {
    public class MindComponent : Component, IUpdatable {
        public IMind mind { get; }

        public MindComponent(IMind mind) {
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