
# plan

the **Plan** is the secondary layer in the hierarchical planning pipeline.

the purpose of the Plan layer: given a general goal, search the available action space and put together a plan to achieve the goal.

put simply: plan a sequence of actions to satisfy a goal

this is generally implemented via goal-oriented action planning.
in Ducia, this is done using the `ActionPlanningModel` class, which is based on [Activ BeyondGOAP](https://github.com/active-logic/xgoap).

a model is simply a set of variables that indicates an intermediate step in the plan.

for example, in a model for gathering flowers, a `flowersGathered` value would track the number of flowers gathered so far.

goals are specified as predicates: `flowersGathered >= 4` indicates a goal meaning that actions have been taken to increase the number of flowers over this threshold.

## options, costs, and conditions

each action has an associated cost to execute. an action and its cost together are known as an **option**.

each action also specifies preconditions and postconditions:
+ preconditions indicate the requirements for an option to be valid
+ postconditions, a.k.a. effects, indicate the effect of taking an action on the planning model

by specifying our constraints in preconditions, we ensure that all sequences created of these actions are valid.

## planning

selecting an optimal plan given a set of options is fairly straightforward. typically it is done using a graph-search algorithm such as A* to find the path to the goal with the least cost.

the solver is called by using `Solver<T>.Next(model, goal)` given a model instance

if no valid combination of the options leads to the goal, the solver returns `null`.
