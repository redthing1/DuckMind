using Activ.GOAP;

namespace Ducia.Tests.Layers.Plan {
    // planning model using more verbose, original XGOAP type class
    public class BasicRoomCleaner : ActionPlanningModel<BasicRoomCleaner> {
        // - state
        public int workDone { get; set; } = 0;
        public int messiness { get; set; } = 0;

        // - const
        public const int RELAX_COST = 1;
        public const int CLEAN_COST = 10;
        public const int MAX_MESSY = 6;

        protected override Option[] ActionOptions => new Option[] {relax, cleanRoom};

        public Cost relax() {
            if (messiness >= MAX_MESSY) return false;
            workDone += 1;
            return RELAX_COST;
        }

        public Cost cleanRoom() {
            if (messiness == 0) return false;
            messiness = 0;
            return CLEAN_COST;
        }

        public override BasicRoomCleaner Clone(BasicRoomCleaner b) {
            b.workDone = workDone;
            b.messiness = messiness;

            return b;
        }

        public override bool Equals(BasicRoomCleaner b) {
            return b.workDone == workDone && b.messiness == messiness;
        }

        public override int GetHashCode() {
            return (workDone, messiness).GetHashCode();
        }
    }

    // planning model using more concise, less boilerplate smart action planning model
    public class SmartRoomCleaner : SmartActionPlanningModel<SmartRoomCleaner> {
        // - state
        public int workDone { get; set; } = 0;
        public int messiness { get; set; } = 0;

        // - const
        public const int RELAX_COST = 1;
        public const int CLEAN_COST = 10;
        public const int MAX_MESSY = 6;

        protected override Option[] ActionOptions => new Option[] {relax, cleanRoom};

        public Cost relax() {
            if (messiness >= MAX_MESSY) return false;
            workDone += 1;
            return RELAX_COST;
        }

        public Cost cleanRoom() {
            if (messiness == 0) return false;
            messiness = 0;
            return CLEAN_COST;
        }
    }
}
