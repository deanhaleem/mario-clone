using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class FirePowerUpState : PowerUpState
    {
        private int attackTimer;
        private float elapsedTime;

        public FirePowerUpState(IPlayer player) : base(player)
        {

        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime > Utilities.AttackDelay)
            {
                attackTimer = 0;
                elapsedTime = 0;
            }

            base.Update(gameTime);
        }

        public override void Attack()
        {
            if (attackTimer < Utilities.AttackLimit)
            {
                Player.ActionState.Attack(typeof(Fireball));
                attackTimer++;
            }
        }

        public override void Upgrade() { }
    }
}
