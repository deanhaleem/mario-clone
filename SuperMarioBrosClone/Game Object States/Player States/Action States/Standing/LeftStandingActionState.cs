namespace SuperMarioBrosClone
{
    internal class LeftStandingActionState : LeftActionState
    {
        public LeftStandingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.ActionState = new LeftJumpingActionState(Player);
        }

        public override void WalkRight()
        {
            Player.ActionState = new RightStandingActionState(Player);
        }

        public override void WalkLeft()
        {
            Player.ActionState = new LeftWalkingActionState(Player);
        }

        public override void Crouch()
        {
            Player.ActionState = new LeftCrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new LeftFallingActionState(Player);
        }
    }
}
