using System.Collections.Generic;

namespace Ducia.Framework.DGU {
    public class DGUAgent {
        public AgentEnvironment environment;
        public DGUPlanner planner;
        public FactBank factMemory;
        public List<Sensor> sensors;
        public List<Drive> drives;
        public List<Goal> goals;

        #region SENSE THINK ACT

        void sense() {
            perceive();
        }

        void think() {
            // - update internal state
            updateFacts();
            updateDrives();
            updateGoals();

            // - ask the planning algorithm
            requestPlans();
        }

        void act() {
            propagateEffects();
        }

        #endregion

        private void perceive() { }

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

        private void propagateEffects() { }
    }
}