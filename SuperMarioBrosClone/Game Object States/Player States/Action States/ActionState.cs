using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class ActionState : IActionState
    {
        protected IPlayer Player { get; private set; }

        protected ActionState(IPlayer player)
        {
            this.Player = player;
        }

        public virtual void Decorate()
        {
            Player = Game1.Instance.Player;
        }

        public virtual void Upgrade()
        {
            Player.ActionState = new UpgradingActionState(Player);
        }

        public virtual void Downgrade()
        {
            Player.ActionState = new DowngradingActionState(Player);
        }

        public virtual void WinLevel()
        {
            Player.ActionState = new VictoryActionState(Player);
        }

        public virtual void Warp(Vector2 location, Vector2 velocity)
        {
            Player.ActionState = new WarpingActionState(Player, location, velocity);
        }

        public virtual void Attack(Type projectileType)
        {
            if (Player.Direction == Directions.Left)
            {
                ProjectileFactory.Instance.CreateLeftProjectile(projectileType, Player.HitBox);
            }
            else
            {
                ProjectileFactory.Instance.CreateRightProjectile(projectileType, Player.HitBox);
            }
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Stand() { }
        public virtual void Jump() { }
        public virtual void WalkRight() { }
        public virtual void WalkLeft() { }
        public virtual void Crouch() { }
        public virtual void Run() { }
        public virtual void StopJumping() { }
        public virtual void StopMovingRight() { }
        public virtual void StopMovingLeft() { }
        public virtual void StopCrouching() { }
        public virtual void StopRunning() { }
        public virtual void Fall() { }
        public virtual void Land() { }
    }
}
