namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class VictoryActionState : ActionState
    {
        public VictoryActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
        }

        public override void Jump()
        {
            Player.CutYVelocity();
            Player.ActionState = new JumpingActionState(Player);
        }
    }
}