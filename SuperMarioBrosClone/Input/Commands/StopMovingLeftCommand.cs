using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
{
    internal class StopMovingLeftCommand : Command<IPlayer>
    {
        public StopMovingLeftCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.StopMovingLeft();
        }
    }
}
