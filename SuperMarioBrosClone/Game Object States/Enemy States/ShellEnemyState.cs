namespace SuperMarioBrosClone
{
    internal class ShellEnemyState : EnemyState
    {
        public ShellEnemyState(IEnemy enemy) : base(enemy)
        {
            base.Enemy.CutXVelocity();
            base.Enemy.CutYVelocity();
            base.Enemy.SetMaxVelocity(Physics.ShellMaxVelocity);
        }

        public override void Stomp()
        {
            Enemy.EnemyState = new FlippedEnemyState(Enemy);
        }
    }
}
