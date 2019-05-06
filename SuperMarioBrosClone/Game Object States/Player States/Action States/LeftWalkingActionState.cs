namespace SuperMarioBrosClone
{
    internal class LeftWalkingActionState : LeftActionState
    {
        public LeftWalkingActionState(IPlayer player) : base(player)
        {
            base.Player.CutYVelocity();
            base.Player.ApplyForce(-Physics.PlayerHorizontalAcceleration);
            base.Player.SetMaxVelocity(Physics.MaxPlayerVelocity);
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

        public override void Run()
        {
            Player.ActionState = new LeftRunningActionState(Player);
        }

        public override void StopMovingLeft()
        {
            Player.ActionState = new RightSlidingActionState(Player);
        }
    }
}