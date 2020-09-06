
# plan

the **Plan** is the secondary layer in the hierarchical planning pipeline.

the purpose of the Plan layer: given a general goal, search the available action space and put together a plan to achieve the goal.

put simply: plan a sequence of actions to satisfy a goal

this is generally implemented via goal-oriented action planning.
in Ducia, this is done using the `ActionPlanningModel` class, which is based on [Activ BeyondGOAP](https://github.com/active-logic/xgoap).

## options, costs, and conditions

each action has an associated cost to execute. an action and its cost together are known as an **option**.

each action also specifies preconditions and postconditions; these are...

## planning

selecting an optimal plan given a set of options is fairly straightforward. typically it is done using a graph-search algorithm such as A* to find the path to the goal with the least cost.
