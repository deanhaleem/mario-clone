namespace SuperMarioBrosClone
{
    internal class WalkRightCommand : Command<IPlayer>
    {
        public WalkRightCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.WalkRight();
        }
    }
}
