using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class PlayerCameraCollisionHandler
    {
        private readonly IPlayer player;
        private readonly ICollision collision;

        public PlayerCameraCollisionHandler(IPlayer player, ICollision collision)
        {
            this.player = player;
            this.collision = collision;
        }

        public void HandleLeftPlayerCameraCollision()
        {
            player.Location += new Vector2(collision.Intersection.Width, 0);
            player.CutXVelocity();
        }

        public void HandleRightPlayerCameraCollision()
        {
            player.Location -= new Vector2(collision.Intersection.Width, 0);
            player.CutXVelocity();
        }
    }
}
