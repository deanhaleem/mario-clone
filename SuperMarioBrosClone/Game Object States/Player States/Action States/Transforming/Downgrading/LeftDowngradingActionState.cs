namespace SuperMarioBrosClone
{
    internal class LeftDowngradingActionState : TransformingActionState
    {
        public LeftDowngradingActionState(IPlayer player) : base(player, Timers.PlayerDowngradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new LeftStandingActionState(Player);

            base.SetStateAfterTransformation();

            Game1.Instance.Player = new BlinkingMario(Player);
            Player.Decorate();
        }
    }
}
