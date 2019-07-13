namespace SuperMarioBrosClone.Input.Commands
{
    internal class DisplayRectanglesCommand : Command<Game1>
    {
        public DisplayRectanglesCommand(Game1 game) : base(game)
        {

        }

        public override void Execute()
        {
            Receiver.ToggleRectangles();
        }
    }
}
