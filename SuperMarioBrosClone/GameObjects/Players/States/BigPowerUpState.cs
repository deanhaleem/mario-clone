namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class BigPowerUpState : PowerUpState
    {
        public BigPowerUpState(IPlayer player) : base(player)
        {

        }

        public override void Upgrade()
        {
            Player.PowerUpState = new FirePowerUpState(Player);

            base.Upgrade();
        }
    }
}
