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
        public virtual void Attack(Type projectileType) { }
        public virtual void Upgrade() { }
        public virtual void Downgrade() { }
        public virtual void WinLevel() { }
        public virtual void Warp(Vector2 location, Vector2 velocity) { }
    }
}
