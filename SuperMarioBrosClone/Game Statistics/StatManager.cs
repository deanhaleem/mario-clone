using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class StatManager
    {
        private ScoreKeeper scoreKeeper;
        private LifeKeeper lifeKeeper;
        private CoinKeeper coinKeeper;
        private Timer timer;

        public int Score => scoreKeeper.Score;
        public int Lives => lifeKeeper.Lives;
        public int Coins => coinKeeper.Coins;
        public int Time => timer.Time;

        public static StatManager Instance { get; } = new StatManager();

        public void LoadContent(ScoreKeeper defaultScoreKeeper, LifeKeeper defaultLifeKeeper, CoinKeeper defaultCoinKeeper, Timer defaultTimer)
        {
            scoreKeeper = defaultScoreKeeper;
            lifeKeeper = defaultLifeKeeper;
            coinKeeper = defaultCoinKeeper;
            timer = defaultTimer;
        }

        public void Update(GameTime gameTime)
        {
            timer.Update(gameTime);
        }

        public void GainPoints(Rectangle pointEventIntersection, string pointEventName)
        {
            scoreKeeper.GainPoints(pointEventIntersection, pointEventName);
        }

        public void GainCoin()
        {
            coinKeeper.PickUpCoin();
        }

        public void GainOrLoseLife(bool isLifeGainingEvent)
        {
            lifeKeeper.GainOrLoseLife(isLifeGainingEvent);
        }

        public void TallyUp()
        {
            timer.TallyUp();
        }

        public void ResetConsecutivePoints()
        {
            scoreKeeper.ResetConsecutivePointCount();
        }

        public void SoftReset()
        {
            timer.Reset();
        }

        public void HardReset()
        {
            scoreKeeper.Reset();
            lifeKeeper.Reset();
            coinKeeper.Reset();
            timer.Reset();
        }
    }
}
