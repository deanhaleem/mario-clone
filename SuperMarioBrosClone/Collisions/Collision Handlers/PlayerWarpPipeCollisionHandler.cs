using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class PlayerWarpPipeCollisionHandler
    {
        private readonly IPlayer player;
        private readonly IPipe warpPipe;

        public PlayerWarpPipeCollisionHandler(IPlayer player, IPipe pipe)
        {
            this.player = player;
            this.warpPipe = pipe;
        }

        public void HandleTopPlayerWarpPipeCollision()
        {
            if (player.CanWarp)
            {
                if (player is BlinkingMario mario)
                {
                    mario.RemoveDecorator();
                }
                player.Warp(warpPipe.WarpLocation, Physics.VerticalWarpVelocity);
            }
        }

        public void HandleBottomPlayerWarpPipeCollision()
        {
            player.Warp(Vector2.Zero, -Physics.VerticalWarpVelocity);
        }

        public void HandleRightPlayerWarpPipeCollision()
        {
            if (player.Direction == Directions.Right && (player.ActionState is RunningActionState || player.ActionState is WalkingActionState))
            {
                if (player is BlinkingMario mario)
                {
                    mario.RemoveDecorator();
                }
                player.Warp(warpPipe.WarpLocation, Physics.HorizontalWarpVelocity);
            }
        }
    }
}
