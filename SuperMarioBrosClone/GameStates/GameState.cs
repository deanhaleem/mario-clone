using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Display;
using SuperMarioBrosClone.Levels;

namespace SuperMarioBrosClone.GameStates
{
    internal abstract class GameState : IGameState
    {
        protected Game1 Game { get; }
        protected ILevel Level { get; }
        protected ICameraController CameraController { get; }

        protected GameState(Game1 game, ILevel level)
        {
            this.Game = game;
            this.Level = level;
            this.CameraController = new CameraController(game.Camera);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void EndLevel() { }
        public virtual void Pause() { }
        public virtual void LoseLife() { }
        public virtual void Transition() { }
        public virtual void Die() { }
        public virtual void Warp() { }
        public virtual void Warp(Vector2 location) { }
        public virtual void TallyUp() { }
    }
}
