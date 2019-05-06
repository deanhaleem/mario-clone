namespace SuperMarioBrosClone
{
    internal class RightDowngradingActionState : TransformingActionState
    {
        public RightDowngradingActionState(IPlayer player) : base(player, Timers.PlayerDowngradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new RightStandingActionState(Player);

            base.SetStateAfterTransformation();

            Game1.Instance.Player = new BlinkingMario(Player);
            Player.Decorate();
        }
    }
}
