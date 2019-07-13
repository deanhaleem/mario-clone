namespace SuperMarioBrosClone.Input.Commands
{
    internal class PauseCommand : Command<Game1>
    {
        public PauseCommand(Game1 game) : base(game)
        {

        }

        public override void Execute()
        {
            Receiver.Pause();
        }
    }
}
