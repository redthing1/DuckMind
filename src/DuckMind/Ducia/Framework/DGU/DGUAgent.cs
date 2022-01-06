using System.Collections.Generic;

namespace Ducia.Framework.DGU {
    public class DGUAgent {
        public AgentEnvironment environment;
        public DGUPlanner planner;
        public FactBank factMemory;
        public List<Sensor> sensors;
        public List<Drive> drives;
        public List<Goal> goals;

        #region Sense-Think-Act outline

        public void sense() {
            perceive();
        }

        public void think() {
            // - update internal state
            updateFacts();
            updateDrives();
            updateGoals();

            // - ask the planning algorithm
            requestPlans();
        }

        public void act() {
            propagateEffects();
        }

        #endregion

        #region Implement Sense

        private void perceive() { }

        #endregion

        #region Implement Think

        private void updateFacts() {
            throw new System.NotImplementedException();
        }

        private void updateDrives() {
            throw new System.NotImplementedException();
        }

        private void updateGoals() {
            throw new System.NotImplementedException();
        }

        private void requestPlans() {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Implement Act

        private void propagateEffects() { }

        #endregion
    }
}