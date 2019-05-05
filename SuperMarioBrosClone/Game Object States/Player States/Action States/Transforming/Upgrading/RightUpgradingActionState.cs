namespace SuperMarioBrosClone
{
    internal class RightUpgradingActionState : TransformingActionState
    {
        public RightUpgradingActionState(IPlayer player) : base(player, Timers.PlayerUpgradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new RightStandingActionState(Player);

            base.SetStateAfterTransformation();
        }
    }
}
