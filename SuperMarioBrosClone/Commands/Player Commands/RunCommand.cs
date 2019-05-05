namespace SuperMarioBrosClone
{
    internal class RunCommand : Command<IPlayer>
    {
        public RunCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.Run();
        }
    }
}
