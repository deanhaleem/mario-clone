using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Statistics
{
    internal class LifeKeeper
    {
        private readonly int initialLives;

        public int Lives { get; private set; }

        public LifeKeeper(int initialLives)
        {
            this.initialLives = initialLives;
            this.Lives = initialLives;
        }

        public void GainOrLoseLife(bool isLifeGainingEvent)
        {
            Lives += isLifeGainingEvent ? Utilities.LifeGained : -Utilities.LifeGained;
        }

        public void Reset()
        {
            Lives = initialLives;
        }
    }
}
