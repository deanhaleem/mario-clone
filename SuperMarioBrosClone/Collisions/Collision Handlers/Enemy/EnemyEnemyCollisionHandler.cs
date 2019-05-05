using System;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class EnemyEnemyCollisionHandler
    {
        private readonly IEnemy instigatingEnemy;
        private readonly IEnemy receivingEnemy;
        private readonly ICollision collision;

        public EnemyEnemyCollisionHandler(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision)
        {
            this.instigatingEnemy = instigatingEnemy;
            this.receivingEnemy = receivingEnemy;
            this.collision = collision;
        }

        public void HandleTopEnemyEnemyCollision()
        {
            instigatingEnemy.Location -= new Vector2(0, collision.Intersection.Height);
            receivingEnemy.Location += new Vector2(0, collision.Intersection.Height);
        }

        public void HandleBottomEnemyEnemyCollision()
        {
            instigatingEnemy.Location += new Vector2(0, collision.Intersection.Height);
            receivingEnemy.Location -= new Vector2(0, collision.Intersection.Height);
        }

        public void HandleLeftEnemyEnemyCollision()
        {
            instigatingEnemy.Location += new Vector2(collision.Intersection.Width, 0);
            receivingEnemy.Location -= new Vector2(collision.Intersection.Width, 0);
            instigatingEnemy.ChangeDirection();
            receivingEnemy.ChangeDirection();
        }

        public void HandleRightEnemyEnemyCollision()
        {
            instigatingEnemy.Location -= new Vector2(collision.Intersection.Width, 0);
            receivingEnemy.Location += new Vector2(collision.Intersection.Width, 0);
            instigatingEnemy.ChangeDirection();
            receivingEnemy.ChangeDirection();
        }

        public void HandleLeftEnemyShellCollision()
        {
            if (Math.Abs(receivingEnemy.Velocity.X) >= Physics.ShellSpeed)
            {
                instigatingEnemy.Flip();

                StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
            else
            {
                instigatingEnemy.Location += new Vector2(collision.Intersection.Width, 0);
                instigatingEnemy.ChangeDirection();
            }
        }

        public void HandleRightEnemyShellCollision()
        {
            if (Math.Abs(receivingEnemy.Velocity.X) >= Physics.ShellSpeed)
            {
                instigatingEnemy.Flip();

                StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
            else
            {
                instigatingEnemy.Location -= new Vector2(collision.Intersection.Width, 0);
                instigatingEnemy.ChangeDirection();
            }
        }
    }
}
