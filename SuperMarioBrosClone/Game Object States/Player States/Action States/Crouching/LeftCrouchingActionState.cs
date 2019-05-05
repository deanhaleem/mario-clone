namespace SuperMarioBrosClone
{
    internal class LeftCrouchingActionState : LeftActionState
    {
        public LeftCrouchingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void StopCrouching()
        {
            Player.ActionState = new LeftStandingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new LeftFallingActionState(Player);
        }
    }
}
