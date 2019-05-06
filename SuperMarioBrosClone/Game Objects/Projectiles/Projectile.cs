using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class Projectile : KinematicGameObject, IProjectile
    {
        public IProjectileState ProjectileState { get; set; }

        protected Projectile(Vector2 location, Color color, Vector2 initialVelocity, Vector2 maxVelocity) :
            base(location,  color, maxVelocity)
        {
            this.ProjectileState = new ActiveProjectileState(this);

            base.ApplyImpulse(initialVelocity);
            base.Direction = (Directions) (initialVelocity.X / Math.Abs(initialVelocity.X));
        }

        public override void Update(GameTime gameTime)
        {
            ProjectileState.Update(gameTime);

            base.Update(gameTime);
        }

        public virtual void Destroy()
        {
            ProjectileState.Destroy();
        }
    }
}
