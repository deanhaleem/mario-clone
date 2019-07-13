using System;
using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects
{
    internal abstract class KinematicGameObject : GameObject, IRigidBody
    {
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 maxVelocity;
        private Directions direction;

        public virtual Rectangle ExtendedHitBox =>
            new Rectangle(base.HitBox.X, base.HitBox.Y, base.HitBox.Width, base.HitBox.Height + Offsets.ExtendedHeightOffset);

        public virtual Vector2 Acceleration => acceleration;

        public Directions Direction
        {
            get => direction;
            set
            {
                direction = value;
                SetSprite();
            }
        }

        public virtual Vector2 Velocity
        {
            get => velocity;
            set
            {
                velocity = value;

                if (velocity.X < -maxVelocity.X)
                {
                    velocity.X = -maxVelocity.X;
                }
                else if (velocity.X > maxVelocity.X)
                {
                    velocity.X = maxVelocity.X;
                }

                if (velocity.Y > maxVelocity.Y)
                {
                    velocity.Y = maxVelocity.Y;
                }
            }
        }

        protected KinematicGameObject(Vector2 location, Color color, Vector2 maxVelocity) : base(location, color)
        {
            this.maxVelocity = maxVelocity;
            this.direction = Directions.Right;
        }

        public override void Update(GameTime gameTime)
        {
            Velocity += acceleration * ((float) gameTime.ElapsedGameTime.TotalSeconds - Physics.DeltaTime);
            Location += velocity;
            base.Update(gameTime);
        }

        public virtual void ApplyImpulse(Vector2 impulse)
        {
            Velocity += impulse;
        }

        public virtual void ApplyForce(Vector2 force)
        {
            acceleration = force;
        }

        public virtual void CutXVelocity()
        {
            velocity.X = 0;
            acceleration.X = 0;
        }

        public virtual void CutYVelocity()
        {
            velocity.Y = 0;
            acceleration.Y = 0;
        }

        public virtual void Land()
        {
            velocity.Y = 0;
            acceleration.Y = 0;
        }

        public virtual void Fall()
        {
            velocity.Y = 3f;
        }

        public virtual void ChangeDirection()
        {
            velocity.X *= -1;
            acceleration.X *= -1;
            Direction = (Directions) (velocity.X / Math.Abs(velocity.X));
        }

        public virtual void SetMaxVelocity(Vector2 updatedMaxVelocity)
        {
            maxVelocity = updatedMaxVelocity;
        }
    }
}
