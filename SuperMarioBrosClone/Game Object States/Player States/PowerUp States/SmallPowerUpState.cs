namespace SuperMarioBrosClone
{
    internal class SmallPowerUpState : PowerUpState
    {
        public SmallPowerUpState(IPlayer player) : base(player)
        {

        }

        public override void TakeDamage()
        {
            Player.PowerUpState = new DeadPowerUpState(Player);
            Player.ActionState = new DeadActionState(Player);
        }

        public override void Upgrade()
        {
            Player.PowerUpState = new BigPowerUpState(Player);

            base.Upgrade();
        }
    }
}
