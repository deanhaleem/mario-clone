using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.GameObjects.Blocks;
using SuperMarioBrosClone.GameObjects.Items;
using SuperMarioBrosClone.GameObjects.Players;
using SuperMarioBrosClone.GameObjects.Players.States;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;
using System.Reflection;
using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Collisions.Handlers
{
    internal class PlayerBlockCollisionHandler
    {
        private readonly IPlayer player;
        private readonly IBlock block;
        private readonly ICollision collision;

        public PlayerBlockCollisionHandler(IPlayer player, IBlock block, ICollision collision)
        {
            this.player = player;
            this.block = block;
            this.collision = collision;
        }

        public void HandleTopPlayerBlockCollision()
        {
            player.Location -= new Vector2(0, collision.Intersection.Height);

            if (player.ActionState is FallingActionState)
            {
                player.Land();
                player.CutYVelocity();

                StatManager.Instance.ResetConsecutivePoints();
            }
        }

        public void HandleBottomPlayerBlockCollision()
        {
            player.Location += new Vector2(0, collision.Intersection.Height);

            if (player.ActionState is JumpingActionState)
            {
                player.Location += new Vector2(0, collision.Intersection.Height);
                player.ApplyImpulse(Physics.BlockBumpForce - new Vector2(0, player.Velocity.Y));
                block.Bump();

                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandleLeftPlayerBlockCollision()
        {
            player.Location += new Vector2(collision.Intersection.Width, 0);

            if (player.Velocity.X < 0)
            {
                player.CutXVelocity();
            }
        }

        public void HandleRightPlayerBlockCollision()
        {
            player.Location -= new Vector2(collision.Intersection.Width, 0);

            if (player.Velocity.X > 0)
            {
                player.CutXVelocity();
            }
        }

        public void HandleBottomNonSmallPlayerPowerUpBlockCollision()
        {
            player.Location += new Vector2(0, collision.Intersection.Height);

            if (player.ActionState is JumpingActionState)
            {
                player.ApplyImpulse(Physics.BlockBumpForce - new Vector2(0, player.Velocity.Y));
                ((IItemContainer) block).ItemType = typeof(FireFlower);
                block.Bump();

                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandleBottomPlayerHiddenBlockCollision()
        {
            player.Location += new Vector2(0, collision.Intersection.Height);

            if (player.ActionState is JumpingActionState)
            {
                player.ApplyImpulse(Physics.BlockBumpForce - new Vector2(0, player.Velocity.Y));
                block.Bump();

                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandleDestroyingPlayerBlockCollision()
        {
            player.Location += new Vector2(0, collision.Intersection.Height);

            if (player.ActionState is JumpingActionState)
            {
                player.ApplyImpulse(Physics.BlockBumpForce - new Vector2(0, player.Velocity.Y));
                block.Destroy();

                StatManager.Instance.GainPoints(collision.Intersection, MethodBase.GetCurrentMethod().Name);
                SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
            }
        }

        public void HandleTopPlayerPipeCollision()
        {
            if (!(player.ActionState is WarpingActionState))
            {
                player.Location -= new Vector2(0, collision.Intersection.Height);

                if (player.ActionState is FallingActionState)
                {
                    player.Land();
                    player.CutYVelocity();

                    StatManager.Instance.ResetConsecutivePoints();
                }
            }
        }

        public void HandleBottomPlayerPipeCollision()
        {
            if (!(player.ActionState is WarpingActionState))
            {
                if (player.ActionState is JumpingActionState)
                {
                    player.Location += new Vector2(0, collision.Intersection.Height);
                    player.ApplyImpulse(Physics.BlockBumpForce - new Vector2(0, player.Velocity.Y));
                    block.Bump();

                    SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
                }
            }
        }

        public void HandleLeftPlayerPipeCollision()
        {
            if (!(player.ActionState is WarpingActionState))
            {
                player.Location += new Vector2(collision.Intersection.Width, 0);

                if (player.Velocity.X < 0)
                {
                    player.CutXVelocity();
                }
            }
        }

        public void HandleRightPlayerPipeCollision()
        {
            if (!(player.ActionState is WarpingActionState))
            {
                player.Location -= new Vector2(collision.Intersection.Width, 0);

                if (player.Velocity.X > 0)
                {
                    player.CutXVelocity();
                }
            }
        }
    }
}
