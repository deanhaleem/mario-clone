using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    internal class WarpingGameState : GameState
    {
        public WarpingGameState(Game1 game, ILevel level) : base(game, level)
        {
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            Level.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);

            Level.CleanUp(Game.Camera.HitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        public override void Warp()
        {
            SoundManager.Instance.StopSong();
            Game.GameState = new PlayingGameState(Game, Level);
        }

        public override void Warp(Vector2 location)
        {
            SoundManager.Instance.StopSong();
            CameraController.SetCameraLocation(new Vector2(location.X - Offsets.WarpCameraOffset, 0));
            Game.GameState = new PlayingGameState(Game, Level);
        }
    }
}
