using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class RunningActionState : ActionState
    {
        public RunningActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerHorizontalAcceleration * (int) player.Direction);
            base.Player.SetMaxVelocity(Physics.PlayerMaxRunningVelocity);
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

        public override void StopRunning()
        {
            Player.ActionState = new WalkingActionState(Player);
        }
    }
}