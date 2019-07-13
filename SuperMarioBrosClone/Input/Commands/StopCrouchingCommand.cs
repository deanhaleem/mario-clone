using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
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
