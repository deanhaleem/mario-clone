using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
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
