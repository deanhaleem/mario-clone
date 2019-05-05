namespace SuperMarioBrosClone
{
    internal class RightStandingActionState : RightActionState
    {
        public RightStandingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.ActionState = new RightJumpingActionState(Player);
        }

        public override void WalkRight()
        {
            Player.ActionState = new RightWalkingActionState(Player);
        }

        public override void WalkLeft()
        {
            Player.ActionState = new LeftStandingActionState(Player);
        }

        public override void Crouch()
        {
            Player.ActionState = new RightCrouchingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new RightFallingActionState(Player);
        }
    }
}
