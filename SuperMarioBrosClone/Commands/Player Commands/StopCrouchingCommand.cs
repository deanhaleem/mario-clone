namespace SuperMarioBrosClone
{
    internal class StopCrouchingCommand : Command<IPlayer>
    {
        public StopCrouchingCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopCrouching();
        }
    }
}
