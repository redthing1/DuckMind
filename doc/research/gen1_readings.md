# duckmind gen1 readings

## An Introduction to Utility Theory
http://www.gameaipro.com/GameAIPro/GameAIPro_Chapter09_An_Introduction_to_Utility_Theory.pdf

[GameAIPro_Chapter09_An_Introduction_to_Utility_Theory.pdf](../papers/GameAIPro_Chapter09_An_Introduction_to_Utility_Theory.pdf)

A broad, general overview of a basic utility based ai.

## Dual-Utility Reasoning
http://www.gameaipro.com/GameAIPro2/GameAIPro2_Chapter03_Dual-Utility_Reasoning.pdf

[](../papers/)

> There are two common ways of using utility to make a decision. The first, which we will call absolute utility, simply evaluates each option and takes the one with the highest score. The second, relative utility, selects an option at random, but it uses the score of each option to define the probability that it will be selected. The probability for selecting an option (P O ) is determined by dividing the utility of that option (U O) by the total utility of all options

> Dual-utility reasoning is an approach that combines absolute and relative utilities into a synergistic whole. It avoids the weaknesses of both approaches by combining them together and is also more flexible and expressive for the game designers. The big idea is that rather than assigning a single utility value to each option, we assign two: a rank and a weight. Rank uses absolute utility to divide the options into categories, and we only select options from the best category. Weight is used to evaluate options within the context of their category. Once we’ve found the category with the highest rank, we select from among the options in that category using weight-based random.

on the algorithm:

> The algorithm for actually selecting an option is as follows: First, go through all of the options and eliminate any that have a weight that is less than or equal to zero. These options can’t be selected by the weight-based portion of the reasoner anyway, and eliminating them now makes the process simpler. In addition, this gives the designers a convenient way to mark an option as invalid or inappropriate given current circumstances. If an option shouldn’t be selected, simply set its weight to zero and it will be rejected regardless of rank.

> Second, find the highest rank among the options that remain, and eliminate any options whose rank is less than this. Again, what we are doing is finding the most important category and eliminating the options that don’t belong to it.

> Third, find the highest weight from among the options that remain, and eliminate options whose weight is less than some percentage of this. This step is optional, and the percentage that is used should be configurable on a per-decision basis. Conceptually, what we are doing is finding the options that really aren’t all that appropriate (and thus have been given very low weight) and ensuring that the random number generator doesn’t decide to pick them anyway. What remains are plausible (not stupid) options.

## (GOAP) Symbolic Representation of Game World State: Toward Real-Time Planning in Games
https://www.semanticscholar.org/paper/Symbolic-Representation-of-Game-World-State%3A-Toward-Orkin/3400fe6b3d7055fb4d2d5cb742f70fc8667bbd35


[GOAP Symbolic Representation of Game World State.pdf](../papers/GOAP Symbolic Representation of Game World State.pdf)

an overview of GOAP architecture

> At the top level, an NPC has a set of goals that he or she wants to satisfy. The NPC tries to satisfy the goal or goals that are most relevant to his or her current situation, based on some prioritization. A planner searches for the sequence of actions that will satisfy the goal. Each action may have preconditions, which also need to be satisfied by the planner [Nilsson98].

> There is no explicit mapping between goals and actions, or actions to other actions. The planner searches for valid sequences of actions, and considers an action to be a valid neighbor if it has an effect that solves some unsatisfied symbol in the goal state, as described in [Orkin03]. This decoupling of goals and actions facilitates sharing of behaviors, as it allows developers to pick and choose which goals and actions will be available to an NPC, or to all NPCs in a game. Conversely, decoupling allows developers to choose goals or actions to exclude from the set of possible behaviors.

> A GOAP system, with decoupled actions and goals with no explicit connections, gives a separation between implementation and data that is better suited for the workflow of game developers. Engineers implement the atomic actions and goals, and embed the preconditions and effects within. Designers use data files to specify which goals and actions are available to different types of NPCs. This lets designers think about what the NPCs can do, without having to worry about the logic of when or how an NPC decides to do it. As long as Engineers specify appropriate preconditions and effects, NPCs will make use of the various goals and actions when it makes sense.

> These scenarios are not remarkable on their own, as the same results could be achieved with an FSM or RBS. The beauty of the GOAP solution is that it does not require any explicit rules to define how to handle blocked doors or stolen weapons. Reasonable solutions fall out for free based on the preconditions and effects of actions sequenced to satisfy goals. An empty-handed NPC with the goal of attacking an enemy satisfies the precondition of being armed by obtaining a weapon in any way possible. When an NPC finds his desired path obstructed by an impassable door, he abandons his plan and formulates a new one.

> We represent the state of the world with a data structure that consists of a fixed-size array of symbols, implemented as key-value pairs. Keys are represented by enumerated world properties. Values are a union of possible data types. Each NPC maintains its own symbolic view of the world through a world state member variable. The world state includes symbols for properties such as the NPC’s position, weapon, amount of ammo, target object, and health of target object.

> In order to avoid combinatorial explosion while the planner searches for a valid sequence of actions to satisfy a goal, we hash our actions by the symbols they affect, and apply heuristics to guide the search. Hashing the actions by their effects allows the planner to quickly find candidate actions that may solve one of the unsatisfied symbols of the goal world state. The regressive search is implemented as an A* search that attempts to minimize the number of actions needed to solve the remaining unsatisfied goal world state symbols. [Orkin03] illustrates this process with a diagram. While hashing and heuristics optimize the planner’s search, we still do not want to plan more often than we need to. We only formulate a new plan when the current plan has been invalidated, or the most relevant goal has changed. The frequency of re-planning varies depending on the NPC’s surroundings, but is far less frequent than every frame. The time between planner searches can sometimes be measured in minutes!

> The purpose of representing game state symbolically is to allow the planner to make connections between goals and actions, and actions to other actions. If there are preconditions that the planner is not intended to solve, they do not need to be represented by symbols.

> Currently games handle action planning and path finding separately. A GOAP architecture shares much in common with a pathfinder, and it may be beneficial to merge these two systems. Aside from the implementation benefits of code sharing, NPCs could behave much more intelligently if they could factor their goals into their pathfinding heuristics.
