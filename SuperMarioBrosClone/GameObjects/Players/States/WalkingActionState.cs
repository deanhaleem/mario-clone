using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class WalkingActionState : ActionState
    {
        public WalkingActionState(IPlayer player) : base(player)
        {
            base.Player.CutYVelocity();
            base.Player.ApplyForce(Physics.PlayerHorizontalAcceleration * (int) Player.Direction);
            base.Player.SetMaxVelocity(Physics.MaxPlayerVelocity);
        }

        public override void Jump()
        {
            Player.ActionState = new JumpingActionState(Player);
        }

        public override void WalkRight()
        {
            if (Player.Direction == Directions.Left)
            {
                Player.ActionState = new SlidingActionState(Player);
            }
        }

        public override void WalkLeft()
        {
            if (Player.Direction == Directions.Right)
            {
                Player.ActionState = new SlidingActionState(Player);
            }
        }

        public override void Crouch()
        {
            Player.ActionState = new CrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new FallingActionState(Player);
        }

        public override void Run()
        {
            Player.ActionState = new RunningActionState(Player);
        }

        public override void StopMovingRight()
        {
            if (Player.Direction == Directions.Right)
            {
                Player.ActionState = new SlidingActionState(Player);
            }
        }

        public override void StopMovingLeft()
        {
            if (Player.Direction == Directions.Left)
            {
                Player.ActionState = new SlidingActionState(Player);
            }
        }
    }
}