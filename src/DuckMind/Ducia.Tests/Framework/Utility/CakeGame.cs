namespace Ducia.Tests.Framework.Utility {
    public class CakeGame {
        // - actors
        public Baker baker;

        // - state
        public int cakesBaked = 0;
        public int flour = 0;
        public float fatigue = 0f;
        public int orders = 0;

        // - consts
        public const int FLOUR_PER_CAKE = 100;
        public const float ENERGY_PER_CAKE = 0.05f;
        public const int ANGERY_CUSTOMERS = 10; // the number of orders where they get mad
        public const int CAKES_PER_SESSION = 4;
        public const int STORE_FLOUR = 1000;

        public CakeGame() {
            baker = new Baker(this);
        }

        public void sleepBed() {
            fatigue = 0;
        }

        public void bakeCake() {
            for (int i = 0; i < CAKES_PER_SESSION && flour > FLOUR_PER_CAKE && orders > 0; i++) {
                // bake
                flour -= FLOUR_PER_CAKE; // used flour
                cakesBaked++; // got a cake
                orders--; // completed an order 
                fatigue += ENERGY_PER_CAKE; // used some energy
            }
        }

        public void buyFlour() {
            flour += STORE_FLOUR;
        }

        /// <summary>
        /// step the game
        /// </summary>
        /// <returns>whether the baker is alive</returns>
        public bool step() {
            // daily orders
            orders += 2;

            // make your move, baker
            var log = baker.act();

            // check conditions
            if (fatigue >= 1f) return false; // died of exhaustion
            if (orders >= ANGERY_CUSTOMERS) return false; // didn't do orders
            if (flour <= 0) return false; // ran out of flour

            // still alive... for now
            return true;
        }

        /// <summary>
        /// run the game for n steps
        /// </summary>
        /// <param name="iterations"></param>
        /// <returns>whether the baker is still alive</returns>
        public bool run(int iterations) {
            for (int i = 0; i < iterations; i++) {
                var result = step();
                // the baker is dead
                if (!result) return false;
            }

            return true;
        }
    }
}