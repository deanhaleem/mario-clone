namespace SuperMarioBrosClone
{
    internal class RightCrouchingActionState : RightActionState
    {
        public RightCrouchingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void StopCrouching()
        {
            Player.ActionState = new RightStandingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new RightFallingActionState(Player);
        }
    }
}
