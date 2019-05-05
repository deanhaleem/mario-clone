using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBrosClone
{
    internal class PlayingGameState : GameState
    {
        private readonly List<IController> controllers;

        public PlayingGameState(Game1 game, ILevel level) : base(game, level)
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

            SoundManager.Instance.PlaySong(Game.Player);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            Level.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);
            StatManager.Instance.Update(gameTime);
            CameraController.Update(Game.Player.Location.X, Game.Player.Velocity.X);

            Level.CleanUp(Game.Camera.HitBox);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Level.Draw(spriteBatch);
        }

        public override void Transition()
        {
            Game.GameState = new TransitioningGameState(Game, Level);
        }

        public override void Pause()
        {
            Game.GameState = new PausedGameState(Game, Level);
        }

        public override void LoseLife()
        {
            Game.GameState = StatManager.Instance.Lives > 0
                ? (IGameState) new LivesLeftGameState(Game, Level)
                : new GameOverGameState(Game, Level);
        }

        public override void EndLevel()
        {
            Game.GameState = new VictoryGameState(Game, Level);
        }

        public override void Die()
        {
            Game.GameState = new DeadPlayerGameState(Game, Level);
        }

        public override void Warp()
        {
            Game.GameState = new WarpingGameState(Game, Level);
        }
    }
}
