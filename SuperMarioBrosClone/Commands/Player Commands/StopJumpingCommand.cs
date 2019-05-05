namespace SuperMarioBrosClone
{
    internal class StopJumpingCommand : Command<IPlayer>
    {
        public StopJumpingCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopJumping();
        }
    }
}
