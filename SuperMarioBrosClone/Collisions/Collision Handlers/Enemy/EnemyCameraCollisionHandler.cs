namespace SuperMarioBrosClone
{
    internal class EnemyCameraCollisionHandler
    {
        private readonly IEnemy enemy;

        public EnemyCameraCollisionHandler(IEnemy enemy)
        {
            this.enemy = enemy;
        }

        public void HandleRightEnemyCameraCollision()
        {
            enemy.WakeUp();
        }
    }
}
