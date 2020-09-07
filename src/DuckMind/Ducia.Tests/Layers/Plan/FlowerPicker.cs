using Activ.GOAP;

namespace Ducia.Tests.Layers.Plan {
    /// <summary>
    /// picking flowers
    /// </summary>
    public class FlowerPicker : ActionPlanningModel<FlowerPicker> {
        // - state
        public int flowersPicked = 0;
        public int bucket = 0;

        // - const
        public const int BUCKET_CAPACITY = 4;
        public const int PICK_COST = 1;
        public const int DUMP_COST = 6;

        public override Option[] ActionOptions => new Option[] {pickFlower, dumpBucket};

        public Cost pickFlower() {
            // precondition
            if (bucket >= BUCKET_CAPACITY) return false;

            // action
            bucket++;

            // cost
            return PICK_COST;
        }

        public Cost dumpBucket() {
            // precondition
            if (bucket == 0) return false;

            // action
            flowersPicked += bucket;
            bucket = 0;

            // cost
            return DUMP_COST;
        }

        #region Type Overrides

        public override FlowerPicker Clone(FlowerPicker b) {
            b.flowersPicked = flowersPicked;
            b.bucket = bucket;

            return b;
        }

        public override bool Equals(object? obj) {
            if (obj is FlowerPicker b) {
                return b.flowersPicked == flowersPicked && b.bucket == bucket;
            }
            else return false;
        }

        public override int GetHashCode() {
            return (flowersPicked, bucket).GetHashCode();
        }

        #endregion
    }
}