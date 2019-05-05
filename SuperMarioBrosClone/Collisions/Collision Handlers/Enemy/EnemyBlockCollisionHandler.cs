using Microsoft.Xna.Framework;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class EnemyBlockCollisionHandler
    {
        private readonly IEnemy enemy;
        private readonly IBlock block;
        private readonly ICollision collision;

        public EnemyBlockCollisionHandler(IEnemy enemy, IBlock block, ICollision collision)
        {
            this.enemy = enemy;
            this.block = block;
            this.collision = collision;
        }

        public void HandleTopEnemyBlockCollision()
        {
            enemy.Location -= new Vector2(0, collision.Intersection.Height);
            enemy.Land();

            if (block.BlockState is BumpedBlockState || block.BlockState is DestroyedBlockState)
            {
                enemy.Flip();

                StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandleBottomEnemyBlockCollision()
        {
            enemy.Location += new Vector2(0, collision.Intersection.Height);
        }

        public void HandleLeftEnemyBlockCollision()
        {
            enemy.Location += new Vector2(collision.Intersection.Width, 0);
            enemy.ChangeDirection();
        }

        public void HandleRightEnemyBlockCollision()
        {
            enemy.Location -= new Vector2(collision.Intersection.Width, 0);
            enemy.ChangeDirection();
        }
    }
}
