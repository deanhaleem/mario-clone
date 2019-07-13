using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Statistics;

namespace SuperMarioBrosClone.Collisions.Responders
{
    internal class EnemyProjectileCollisionResponder : ICollisionResponder
    {
        public void RespondToCollision(ICollidable collisionInstigator, ICollidable collisionReceiver, ICollision collision)
        {
            if (collisionInstigator is IEnemy enemy)
            {
                enemy.Flip();
                (collisionReceiver as IProjectile)?.Destroy();
            }
            else
            {
                (collisionReceiver as IEnemy)?.Flip();
                (collisionInstigator as IProjectile)?.Destroy();
            }

            StatManager.Instance.GainPoints(collision.Intersection, collisionInstigator.GetType().Name + collisionReceiver.GetType().Name);
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }
    }
}
