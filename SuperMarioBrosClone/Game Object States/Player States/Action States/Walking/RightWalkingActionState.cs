namespace SuperMarioBrosClone
{
    internal class RightWalkingActionState : RightActionState
    {
        public RightWalkingActionState(IPlayer player) : base(player)
        {
            base.Player.CutYVelocity();
            base.Player.ApplyForce(Physics.PlayerHorizontalAcceleration);
            base.Player.SetMaxVelocity(Physics.MaxPlayerVelocity);
        }

        public override void Jump()
        {
            Player.ActionState = new RightJumpingActionState(Player);
        }

        public override void WalkLeft()
        {
            Player.ActionState = new LeftSlidingActionState(Player);
        }

        public override void Crouch()
        {
            Player.ActionState = new RightCrouchingActionState(Player);
        }

        public override void Run()
        {
            Player.ActionState = new RightRunningActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new RightFallingActionState(Player);
        }

        public override void StopMovingRight()
        {
            Player.ActionState = new LeftSlidingActionState(Player);
        }
    }
}
