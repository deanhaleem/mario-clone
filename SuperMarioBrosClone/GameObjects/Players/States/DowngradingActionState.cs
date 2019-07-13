using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class DowngradingActionState : TransformingActionState
    {
        public DowngradingActionState(IPlayer player) : base(player, Timers.PlayerDowngradeTimer)
        {

        }

        protected override void SetStateAfterTransformation()
        {
            Player.ActionState = new StandingActionState(Player);

            base.SetStateAfterTransformation();

            Game1.Instance.Player = new BlinkingMario(Player);
            Player.Decorate();
        }
    }
}