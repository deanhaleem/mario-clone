using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Players.States;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players
{
    internal abstract class Player : KinematicGameObject, IPlayer
    {
        private IActionState playerActionState;

        protected override string SpriteName =>
            PowerUpState.GetType().Name + Direction + playerActionState.GetType().Name + GetType().Name;

        public bool CanWarp { get; set; }
        public IPowerUpState PowerUpState { get; set; }

        public IActionState ActionState
        {
            get => playerActionState;
            set
            {
                playerActionState = value;
                SetSprite();
            }
        }

        protected Player(Vector2 location, Color color) : base(location, color, Physics.MaxPlayerVelocity)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Location.Y > Locations.WorldBoundary.Y || StatManager.Instance.Time <= 0)
            {
                PowerUpState.TurnDead();
            }
            PowerUpState.Update(gameTime);
            playerActionState.Update(gameTime);
            base.Update(gameTime);
        }

        public virtual void Stand()
        {
            playerActionState.Stand();
        }

        public virtual void Jump()
        {
            playerActionState.Jump();
        }

        public virtual void WalkRight()
        {
            playerActionState.WalkRight();
        }

        public virtual void WalkLeft()
        {
            playerActionState.WalkLeft();
        }

        public virtual void Crouch()
        {
            if (!(PowerUpState is SmallPowerUpState))
            {
                playerActionState.Crouch();
            }
            CanWarp = true;
        }

        public virtual void Run()
        {
            playerActionState.Run();
        }

        public override void Fall()
        {
            playerActionState.Fall();
        }

        public override void Land()
        {
            playerActionState.Land();
            base.Land();
        }

        public virtual void Attack()
        {
            PowerUpState.Attack();
        }

        public virtual void StopRunning()
        {
            playerActionState.StopRunning();
        }

        public virtual void StopMovingRight()
        {
            playerActionState.StopMovingRight();
        }

        public virtual void StopMovingLeft()
        {
            playerActionState.StopMovingLeft();
        }

        public virtual void StopCrouching()
        {
            playerActionState.StopCrouching();
            CanWarp = false;
        }

        public virtual void StopJumping()
        {
            playerActionState.StopJumping();
        }

        public virtual void TakeDamage()
        {
            PowerUpState.TakeDamage();
        }

        public virtual void Upgrade()
        {
            PowerUpState.Upgrade();
        }

        public virtual void Decorate()
        {
            PowerUpState.Decorate();
            playerActionState.Decorate();
        }

        public virtual void TurnDead()
        {
            PowerUpState.TurnDead();
        }

        public virtual void Warp(Vector2 location, Vector2 velocity)
        {
            ActionState.Warp(location, velocity);
        }

        public virtual void WinLevel()
        {
            ActionState.WinLevel();
        }
    }
}
