using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class UpgradingActionState : TransformingActionState
    {
        public UpgradingActionState(IPlayer player) : base(player, Timers.PlayerUpgradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new StandingActionState(Player);

            base.SetStateAfterTransformation();
        }
    }
}