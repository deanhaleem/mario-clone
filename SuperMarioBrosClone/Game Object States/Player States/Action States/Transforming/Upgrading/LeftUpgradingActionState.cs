namespace SuperMarioBrosClone
{
    internal class LeftUpgradingActionState : TransformingActionState
    {
        public LeftUpgradingActionState(IPlayer player) : base(player, Timers.PlayerUpgradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new LeftStandingActionState(Player);

            base.SetStateAfterTransformation();
        }
    }
}
