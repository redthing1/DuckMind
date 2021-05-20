# duckmind gen1 readings

## An Introduction to Utility Theory
http://www.gameaipro.com/GameAIPro/GameAIPro_Chapter09_An_Introduction_to_Utility_Theory.pdf

A broad, general overview of a basic utility based ai.

## Dual-Utility Reasoning
http://www.gameaipro.com/GameAIPro2/GameAIPro2_Chapter03_Dual-Utility_Reasoning.pdf

> There are two common ways of using utility to make a decision. The first, which we will call absolute utility, simply evaluates each option and takes the one with the highest score. The second, relative utility, selects an option at random, but it uses the score of each option to define the probability that it will be selected. The probability for selecting an option (P O ) is determined by dividing the utility of that option (U O) by the total utility of all options

> Dual-utility reasoning is an approach that combines absolute and relative utilities into a synergistic whole. It avoids the weaknesses of both approaches by combining them together and is also more flexible and expressive for the game designers. The big idea is that rather than assigning a single utility value to each option, we assign two: a rank and a weight. Rank uses absolute utility to divide the options into categories, and we only select options from the best category. Weight is used to evaluate options within the context of their category. Once we’ve found the category with the highest rank, we select from among the options in that category using weight-based random.

on the algorithm:

> The algorithm for actually selecting an option is as follows: First, go through all of the options and eliminate any that have a weight that is less than or equal to zero. These options can’t be selected by the weight-based portion of the reasoner anyway, and eliminating them now makes the process simpler. In addition, this gives the designers a convenient way to mark an option as invalid or inappropriate given current circumstances. If an option shouldn’t be selected, simply set its weight to zero and it will be rejected regardless of rank.

> Second, find the highest rank among the options that remain, and eliminate any options whose rank is less than this. Again, what we are doing is finding the most important category and eliminating the options that don’t belong to it.

> Third, find the highest weight from among the options that remain, and eliminate options whose weight is less than some percentage of this. This step is optional, and the percentage that is used should be configurable on a per-decision basis. Conceptually, what we are doing is finding the options that really aren’t all that appropriate (and thus have been given very low weight) and ensuring that the random number generator doesn’t decide to pick them anyway. What remains are plausible (not stupid) options.
