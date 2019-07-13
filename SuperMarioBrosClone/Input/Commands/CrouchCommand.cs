using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
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
