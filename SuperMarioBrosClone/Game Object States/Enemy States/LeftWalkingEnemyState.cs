namespace SuperMarioBrosClone
{
    internal class LeftWalkingEnemyState : EnemyState
    {
        public LeftWalkingEnemyState(IEnemy enemy) : base(enemy)
        {

        }

        public override void ChangeDirection()
        {
            Enemy.EnemyState = new RightWalkingEnemyState(Enemy);
        }
    }
}
