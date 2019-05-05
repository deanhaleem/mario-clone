using System.Collections.Generic;

namespace SuperMarioBrosClone
{
    internal class VictoryKeyboardController : IController
    {
        private readonly Dictionary<int, ICommand> commands;
        private int timer;

        public VictoryKeyboardController(Game1 game)
        {
            this.commands = new Dictionary<int, ICommand>
            {
                { 0, new WalkRightCommand(game.Player) },
                { 1, new JumpCommand(game.Player) }
            };
        }

        public void Update()
        {
            if (commands.ContainsKey(timer))
            {
                commands[timer].Execute();
            }
            else
            {
                commands[0].Execute();
            }
            timer++;
        }
    }
}
