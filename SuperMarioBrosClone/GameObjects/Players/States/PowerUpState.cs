using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameStates;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal abstract class PowerUpState : IPowerUpState
    {
        protected IPlayer Player { get; private set; }

        protected PowerUpState(IPlayer player)
        {
            this.Player = player;
        }

        public virtual void Upgrade()
        {
            Player.ActionState.Upgrade();
        }

        public virtual void Decorate()
        {
            Player = Game1.Instance.Player;
        }

        public virtual void TurnDead()
        {
            if (!(Game1.Instance.GameState is VictoryGameState))
            {
                Player.PowerUpState = new DeadPowerUpState(Player);
                Player.ActionState = new DeadActionState(Player);
            }
        }

        public virtual void TakeDamage()
        {
            Player.PowerUpState = new SmallPowerUpState(Player);
            Player.ActionState.Downgrade();
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Attack() { }
    }
}
