using Microsoft.Xna.Framework;
using System;
using System.Reflection;

namespace SuperMarioBrosClone
{
    internal class PlayerEnemyCollisionHandler
    {
        private readonly IPlayer player;
        private readonly IEnemy enemy;
        private readonly ICollision collision;

        public PlayerEnemyCollisionHandler(IPlayer player, IEnemy enemy, ICollision collision)
        {
            this.player = player;
            this.enemy = enemy;
            this.collision = collision;
        }

        public void HandleTopPlayerEnemyCollision()
        {
            player.Location -= new Vector2(0, collision.Intersection.Height);
            player.ApplyImpulse(Physics.BumpEnemyForce - new Vector2(0, player.Velocity.Y));
            enemy.Stomp();

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandleToNonTopPlayerEnemyCollision()
        {
            player.TakeDamage();
        }

        public void HandleFlippingPlayerEnemyCollision()
        {
            enemy.Flip();

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandleDisarmingPlayerEnemyCollision()
        {
            player.Location -= new Vector2(0, collision.Intersection.Height);
            player.ApplyImpulse(Physics.BumpEnemyForce - new Vector2(0, player.Velocity.Y));
            enemy.Disarm();

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandleTopPlayerShellCollision()
        {
            player.Location -= new Vector2(0, collision.Intersection.Height);
            player.ApplyImpulse(Physics.BumpEnemyForce - new Vector2(0, player.Velocity.Y));

            if (Math.Abs(enemy.Velocity.X) >= Physics.ShellSpeed)
            {
                enemy.Stomp();
            }
            else
            {
                enemy.ApplyImpulse(player.HitBox.Center.X > enemy.HitBox.Center.X
                    ? new Vector2(-Physics.ShellSpeed, 0)
                    : new Vector2(Physics.ShellSpeed, 0));
            }

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandleLeftPlayerShellCollision()
        {
            player.Location += new Vector2(collision.Intersection.Width, 0);

            if (Math.Abs(enemy.Velocity.X) >= Physics.ShellSpeed)
            {
                player.TakeDamage();
            }
            else
            {
                enemy.ApplyImpulse(new Vector2(-Physics.ShellSpeed, 0));
            }

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        public void HandleRightPlayerShellCollision()
        {
            player.Location -= new Vector2(collision.Intersection.Width, 0);

            if (Math.Abs(enemy.Velocity.X) >= Physics.ShellSpeed)
            {
                player.TakeDamage();
            }
            else
            {
                enemy.ApplyImpulse(new Vector2(Physics.ShellSpeed, 0));
            }

            StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }
    }
}
