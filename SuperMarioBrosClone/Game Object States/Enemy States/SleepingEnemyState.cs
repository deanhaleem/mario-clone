namespace SuperMarioBrosClone
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
