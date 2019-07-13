using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.GameObjects.Players.States;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players
{
    internal abstract class PlayerDecorator : KinematicGameObject, IPlayer
    {
        private int decorationTimer;

        protected int DecorationTimer
        {
            get => decorationTimer;
            private set
            {
                decorationTimer = value;
                if (decorationTimer == 0)
                {
                    RemoveDecorator();
                }
            }
        }

        protected IPlayer DecoratedPlayer { get; }

        public new Vector2 Location { get => DecoratedPlayer.Location; set => DecoratedPlayer.Location = value; }
        public new Directions Direction { get => DecoratedPlayer.Direction; set => DecoratedPlayer.Direction = value; }
        public override Rectangle HitBox => DecoratedPlayer.HitBox;
        public override Rectangle ExtendedHitBox => ((KinematicGameObject) DecoratedPlayer).ExtendedHitBox;
        public override Vector2 Velocity => DecoratedPlayer.Velocity;
        public override Vector2 Acceleration => DecoratedPlayer.Acceleration;
        public bool CanWarp { get => DecoratedPlayer.CanWarp; set => DecoratedPlayer.CanWarp = value; }
        public virtual IPowerUpState PowerUpState { get => DecoratedPlayer.PowerUpState; set => DecoratedPlayer.PowerUpState = value; }
        public virtual IActionState ActionState { get => DecoratedPlayer.ActionState; set => DecoratedPlayer.ActionState = value; }

        protected PlayerDecorator(IPlayer player, Color color, int time) : base(player.Location, color, Physics.MaxPlayerVelocity)
        {
            this.DecoratedPlayer = player;
            this.decorationTimer = time;
        }

        public virtual void RemoveDecorator()
        {
            Game1.Instance.Player = DecoratedPlayer;
            DecoratedPlayer.Decorate();
            decorationTimer = 0;
        }

        public override void Update(GameTime gameTime)
        {
            DecoratedPlayer.Update(gameTime);
            DecorationTimer--;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DecoratedPlayer.Draw(spriteBatch);
        }

        public virtual void Stand()
        {
            DecoratedPlayer.Stand();
        }

        public virtual void Jump()
        {
            DecoratedPlayer.Jump();
        }

        public virtual void WalkRight()
        {
            DecoratedPlayer.WalkRight();
        }

        public virtual void WalkLeft()
        {
            DecoratedPlayer.WalkLeft();
        }

        public virtual void Crouch()
        {
            DecoratedPlayer.Crouch();
        }

        public virtual void Run()
        {
            DecoratedPlayer.Run();
        }

        public virtual void Attack()
        {
            DecoratedPlayer.Attack();
        }

        public virtual void StopRunning()
        {
            DecoratedPlayer.StopRunning();
        }

        public virtual void StopMovingRight()
        {
            DecoratedPlayer.StopMovingRight();
        }

        public virtual void StopMovingLeft()
        {
            DecoratedPlayer.StopMovingLeft();
        }

        public virtual void StopCrouching()
        {
            DecoratedPlayer.StopCrouching();
        }

        public virtual void StopJumping()
        {
            DecoratedPlayer.StopJumping();
        }

        public virtual void TakeDamage()
        {
            DecoratedPlayer.TakeDamage();
        }

        public virtual void Upgrade()
        {
            DecoratedPlayer.Upgrade();
        }

        public virtual void Decorate()
        {
            DecoratedPlayer.Decorate();
        }

        public virtual void TurnDead()
        {
            DecoratedPlayer.TurnDead();
        }

        public virtual void WinLevel()
        {
            DecoratedPlayer.WinLevel();
        }

        public override void SetSprite(string spriteName)
        {
            DecoratedPlayer.SetSprite(spriteName);
        }

        public override void ApplyImpulse(Vector2 impulse)
        {
            DecoratedPlayer.ApplyImpulse(impulse);
        }

        public override void ApplyForce(Vector2 force)
        {
            DecoratedPlayer.ApplyForce(force);
        }

        public override void CutXVelocity()
        {
            DecoratedPlayer.CutXVelocity();
        }

        public override void CutYVelocity()
        {
            DecoratedPlayer.CutYVelocity();
        }

        public override void Land()
        {
            DecoratedPlayer.Land();
        }

        public override void Fall()
        {
            DecoratedPlayer.Fall();
        }

        public override void ChangeDirection()
        {
            DecoratedPlayer.ChangeDirection();
        }

        public override void SetMaxVelocity(Vector2 velocity)
        {
            DecoratedPlayer.SetMaxVelocity(velocity);
        }

        public virtual void Warp(Vector2 location, Vector2 velocity)
        {
            DecoratedPlayer.Warp(location, velocity);
        }
    }
}
