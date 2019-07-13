using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Levels;
using SuperMarioBrosClone.Statistics;

namespace SuperMarioBrosClone.GameStates
{
    internal class TransitioningGameState : GameState
    {
        public TransitioningGameState(Game1 game, ILevel level) : base(game, level)
        {

        }

        public override void Update(GameTime gameTime)
        {
            Game.Player.Update(gameTime);
            StatManager.Instance.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);

            Level.CleanUp(Game.Camera.HitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        public override void Transition()
        {
            Game.GameState = new PlayingGameState(Game, Level);
        }

        public override void Pause()
        {
            Game.GameState = new PausedGameState(Game, Level);
        }
    }
}
