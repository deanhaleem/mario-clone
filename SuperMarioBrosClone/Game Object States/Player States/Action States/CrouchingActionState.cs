namespace SuperMarioBrosClone
{
    internal class CrouchingActionState : ActionState
    {
        public CrouchingActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void StopCrouching()
        {
            Player.ActionState = new StandingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new FallingActionState(Player);
        }
    }
}