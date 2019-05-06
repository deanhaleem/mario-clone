using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBrosClone
{
    internal class DeadPlayerGameState : GameState
    {
        private readonly List<IController> controllers;

        public DeadPlayerGameState(Game1 game, ILevel level) : base(game, level)
        {
            this.controllers = new List<IController>
            {
                new KeyboardController
                (
                    ( Keys.Z, new JumpCommand(game.Player), new StopJumpingCommand(game.Player), false),
                    ( Keys.Right, new WalkRightCommand(game.Player), new StopMovingRightCommand(game.Player), true),
                    ( Keys.Left, new WalkLeftCommand(game.Player), new StopMovingLeftCommand(game.Player), true),
                    ( Keys.Down, new CrouchCommand(game.Player), new StopCrouchingCommand(game.Player), true),
                    ( Keys.X, new RunCommand(game.Player), new StopRunningCommand(game.Player), true),
                    ( Keys.C, new AttackCommand(game.Player), new NullCommand(), false),
                    ( Keys.Q, new QuitCommand(game), new NullCommand(), true),
                    ( Keys.R, new ResetCommand(game), new NullCommand(), true),
                    ( Keys.P, new PauseCommand(game), new NullCommand(), false),
                    ( Keys.M, new DisplayRectanglesCommand(game), new NullCommand(), false)
                )
            };

            TimedActionManager.Instance.RegisterTimedAction(null, SetStateToLivesLeft, Timers.DeadPlayerTimer);
            SoundManager.Instance.StopSong();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var controller in controllers)
            {
                controller.Update();
            }

            Level.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);

            Level.CleanUp(Game.Camera.HitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        private void SetStateToLivesLeft()
        {
            Game.GameState = StatManager.Instance.Lives > 0
                ? (IGameState) new LivesLeftGameState(Game, Level)
                : new GameOverGameState(Game, Level);
        }
    }
}
