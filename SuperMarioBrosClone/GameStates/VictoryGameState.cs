using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.Input;
using SuperMarioBrosClone.Levels;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameStates
{
    internal class VictoryGameState : GameState
    {
        private readonly IController victoryKeyboardController;
        private bool canLoadNextLevel;
        private bool canWalkToCastle;
        private bool canTallyUp;

        public VictoryGameState(Game1 game, ILevel level) : base(game, level)
        {
            this.victoryKeyboardController = new VictoryKeyboardController(Game);

            TimedActionManager.Instance.RegisterTimedAction(null, AllowPlayerToWalkToCastle, Timers.SlideDownFlagTimer);
            TimedActionManager.Instance.RegisterTimedAction(null, AllowNextLevelLoad, Timers.VictorySongTimer);
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
            SoundManager.Instance.StopSong();
        }

        public override void Update(GameTime gameTime)
        {
            if (canWalkToCastle)
            {
                victoryKeyboardController.Update();
            }
            if (canTallyUp)
            {
                if (StatManager.Instance.Time > 0)
                {
                    StatManager.Instance.TallyUp();
                    StatManager.Instance.GainPoints(Rectangle.Empty, GetType().Name);
                }
                else
                {
                    if (canLoadNextLevel)
                    {
                        TimedActionManager.Instance.RegisterTimedAction(null, Game.HardReset, Timers.DisplayScoreTimer);
                    }
                    SoundManager.Instance.StopSoundEffect();
                }
            }
            Level.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);
            CameraController.Update(Game.Player.Location.X, Game.Player.Velocity.X);

            Level.CleanUp(Game.Camera.HitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        public override void TallyUp()
        {
            canWalkToCastle = false;
            canTallyUp = true;
            SoundManager.Instance.PlayTimeTick();
        }

        private void AllowPlayerToWalkToCastle()
        {
            canWalkToCastle = true;
            SoundManager.Instance.PlaySoundEffect(MethodBase.GetCurrentMethod().Name);
        }

        private void AllowNextLevelLoad()
        {
            canLoadNextLevel = true;
        }
    }
}
