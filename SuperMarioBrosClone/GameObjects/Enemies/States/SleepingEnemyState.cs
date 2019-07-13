using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Enemies.States
{
    internal class SleepingEnemyState : EnemyState
    {
        public SleepingEnemyState(IEnemy enemy) : base(enemy)
        {
            Enemy.CutYVelocity();
        }

        public override void WakeUp()
        {
            Enemy.ApplyImpulse(Physics.EnemyWakeUpImpulse);
            Enemy.EnemyState = new WalkingEnemyState(Enemy);
        }
    }
}
