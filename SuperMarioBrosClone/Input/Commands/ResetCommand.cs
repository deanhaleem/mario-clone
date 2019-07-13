namespace SuperMarioBrosClone.Input.Commands
{
    internal class ResetCommand : Command<Game1>
    {
        public ResetCommand(Game1 game) : base(game)
        {

        }

        public override void Execute()
        {
            Receiver.HardReset();
        }
    }
}
