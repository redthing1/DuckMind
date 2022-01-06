using System.Collections.Generic;
using System.Linq;

namespace Ducia.Calc; 

public class DiscreteProbabilityDistribution<T> {
    private readonly Rng rng;
    private readonly List<(float, T)> probabilities;

    public DiscreteProbabilityDistribution(Rng rng) {
        this.rng = rng;
        probabilities = new List<(float, T)>();
    }

    public DiscreteProbabilityDistribution(Rng rng, (float, T)[] probabilities) {
        this.rng = rng;
        this.probabilities = probabilities.ToList();
    }

    public void add(float probability, T outcome) {
        probabilities.Add((probability, outcome));
    }

    public T next() {
        var r = rng.nextFloat();
        var sum = 0f;
        foreach (var (prob, outcome) in probabilities) {
            if (r >= sum && r < sum + prob) return outcome;

            sum += prob;
        }

        return default!;
    }
}