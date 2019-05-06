namespace SuperMarioBrosClone
{
    internal class LeftRunningActionState : LeftActionState
    {
        public LeftRunningActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(-Physics.PlayerHorizontalAcceleration);
            base.Player.SetMaxVelocity(Physics.PlayerMaxRunningVelocity);
        }

        public override void Jump()
        {
            Player.ActionState = new LeftJumpingActionState(Player);
        }

        public override void WalkRight()
        {
            Player.ActionState = new RightSlidingActionState(Player);
        }

        public override void Crouch()
        {
            Player.ActionState = new LeftCrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new LeftFallingActionState(Player);
        }

        public override void StopMovingLeft()
        {
            Player.ActionState = new RightSlidingActionState(Player);
        }

        public override void StopRunning()
        {
            Player.ActionState = new LeftWalkingActionState(Player);
        }
    }
}
