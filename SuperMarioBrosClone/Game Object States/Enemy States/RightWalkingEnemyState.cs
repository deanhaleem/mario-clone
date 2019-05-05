namespace SuperMarioBrosClone
{
    internal class RightWalkingEnemyState : EnemyState
    {
        public RightWalkingEnemyState(IEnemy enemy) : base(enemy)
        {

        }

        public override void ChangeDirection()
        {
            Enemy.EnemyState = new LeftWalkingEnemyState(Enemy);
        }
    }
}
