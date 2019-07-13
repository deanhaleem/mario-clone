using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Enemies.States
{
    internal class StompedEnemyState : DeadEnemyState
    {
        public StompedEnemyState(IEnemy enemy) : base(enemy)
        {
            base.Enemy.CutXVelocity();
            base.Enemy.CutYVelocity();

            TimedActionManager.Instance.RegisterTimedAction(null, DisposeOfEnemy, Timers.StompedEnemyTimer);
        }

        private void DisposeOfEnemy()
        {
            Game1.Instance.DisposeOfObject(Enemy);
        }
    }
}
