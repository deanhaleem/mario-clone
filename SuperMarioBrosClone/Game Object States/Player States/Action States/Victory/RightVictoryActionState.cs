namespace SuperMarioBrosClone
{
    internal class RightVictoryActionState : ActionState
    {
        public RightVictoryActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.CutYVelocity();
            Player.ActionState = new RightJumpingActionState(Player);
        }
    }
}
