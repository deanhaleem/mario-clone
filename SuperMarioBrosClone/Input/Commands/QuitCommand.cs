namespace SuperMarioBrosClone.Input.Commands
{
    internal class QuitCommand : Command<Game1>
    {
        public QuitCommand(Game1 game) : base(game)
        {

        }

        public override void Execute()
        {
            Receiver.Exit();
        }
    }
}
