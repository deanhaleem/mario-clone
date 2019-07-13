namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class DeadPowerUpState : PowerUpState
    {
        public DeadPowerUpState(IPlayer player) : base(player)
        {

        }

        public override void TurnDead() { }
    }
}
