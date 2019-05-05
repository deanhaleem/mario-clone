namespace SuperMarioBrosClone
{
    internal class CrouchCommand : Command<IPlayer>
    {
        public CrouchCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.Crouch();
        }
    }
}
