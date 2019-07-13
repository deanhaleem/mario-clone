using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
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
