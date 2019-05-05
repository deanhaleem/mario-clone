namespace SuperMarioBrosClone
{
    internal class JumpCommand : Command<IPlayer>
    {
        public JumpCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.Jump();
        }
    }
}
