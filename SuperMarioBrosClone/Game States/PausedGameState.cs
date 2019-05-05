using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBrosClone
{
    internal class PausedGameState : GameState
    {
        private readonly List<IController> controllers;

        public PausedGameState(Game1 game, ILevel level) : base(game, level)
        {
            this.controllers = new List<IController>
            {
                new KeyboardController
                (
                    ( Keys.K, new PauseCommand(game), new NullCommand(), false)
                )
            };

            SoundManager.Instance.PlaySoundEffect(GetType().Name);
            SoundManager.Instance.PauseSong();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        public override void Pause()
        {
            Game.GameState = new PlayingGameState(Game, Level);
        }
    }
}
