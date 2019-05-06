namespace SuperMarioBrosClone
{
    internal class LeftVictoryActionState : ActionState
    {
        public LeftVictoryActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.CutYVelocity();
            Player.ActionState = new LeftJumpingActionState(Player);
        }
    }
}
