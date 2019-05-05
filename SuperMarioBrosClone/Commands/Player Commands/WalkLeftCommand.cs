namespace SuperMarioBrosClone
{
    internal class WalkLeftCommand : Command<IPlayer>
    {
        public WalkLeftCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.WalkLeft();
        }
    }
}
