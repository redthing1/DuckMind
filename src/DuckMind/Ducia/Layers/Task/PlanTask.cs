namespace Ducia {
    public abstract class PlanTask {
        public enum Status {
            /// <summary>
            ///     task is still running
            /// </summary>
            Ongoing,

            /// <summary>
            ///     task completed successfully
            /// </summary>
            Complete,

            /// <summary>
            ///     task failed, but is optional
            /// </summary>
            OptionalFailed,

            /// <summary>
            ///     task failed unrecoverably
            /// </summary>
            Failed
        }

        public abstract Status status();
    }

    public abstract class PlanTask<TMind> : PlanTask where TMind : IMind {
        protected readonly TMind mind;
        public float expiryTime;

        public PlanTask(TMind mind, float expiryTime = 0f) {
            this.mind = mind;
            this.expiryTime = expiryTime;
        }

        /// <summary>
        ///     whether the goal should still be pursued (valid/ongoing)
        /// </summary>
        /// <returns></returns>
        public override Status status() {
            if (expiryTime <= 0) return Status.Ongoing;
            return mind.elapsed < expiryTime ? Status.Ongoing : Status.Failed;
        }
    }
}