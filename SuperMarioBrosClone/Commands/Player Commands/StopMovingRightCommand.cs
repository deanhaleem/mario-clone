namespace SuperMarioBrosClone
{
    internal class StopMovingRightCommand : Command<IPlayer>
    {
        public StopMovingRightCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopMovingRight();
        }
    }
}
