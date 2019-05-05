namespace SuperMarioBrosClone
{
    internal class StopRunningCommand : Command<IPlayer>
    {
        public StopRunningCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopRunning();
        }
    }
}
