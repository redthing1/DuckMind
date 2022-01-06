using System;
using System.Collections.Generic;

namespace Ducia.Framework.DGU;

public class DGUAgent {
    public List<Drive> drives;
    public AgentEnvironment environment;
    public FactBank factMemory;
    public List<Goal> goals;
    public DGUPlanner planner;
    public List<Sensor> sensors;

    #region Implement Sense

    private void perceive() { }

    #endregion

    #region Implement Act

    private void propagateEffects() { }

    #endregion

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

    #region Implement Think

    private void updateFacts() {
        throw new NotImplementedException();
    }

    private void updateDrives() {
        throw new NotImplementedException();
    }

    private void updateGoals() {
        throw new NotImplementedException();
    }

    private void requestPlans() {
        throw new NotImplementedException();
    }

    #endregion
}