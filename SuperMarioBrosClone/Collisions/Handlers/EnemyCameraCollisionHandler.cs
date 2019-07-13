using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Enemies;

namespace SuperMarioBrosClone.Collisions.Handlers
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
