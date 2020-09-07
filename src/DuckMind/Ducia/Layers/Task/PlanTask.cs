namespace Ducia {
    public abstract class PlanTask {
        public enum Status {
            /// <summary>
            /// task is still running
            /// </summary>
            Ongoing,

            /// <summary>
            /// task completed successfully
            /// </summary>
            Complete,

            /// <summary>
            /// task failed, but is optional
            /// </summary>
            OptionalFailed,

            /// <summary>
            /// task failed unrecoverably
            /// </summary>
            Failed
        }

        public abstract Status status();
    }

    public abstract class PlanTask<TMind> : PlanTask where TMind : IMind {
        protected readonly TMind mind;
        public float failureTime = 0f;

        public PlanTask(TMind mind, float reachBefore) {
            this.mind = mind;
            failureTime = reachBefore;
        }

        /// <summary>
        /// whether the goal should still be pursued (valid/ongoing)
        /// </summary>
        /// <returns></returns>
        public override Status status() {
            if (failureTime <= 0) return Status.Ongoing;
            return mind.elapsed < failureTime ? Status.Ongoing : Status.Failed;
        }
    }
}