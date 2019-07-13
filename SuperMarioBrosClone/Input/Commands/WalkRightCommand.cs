using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Input.Commands
{
    internal class WalkRightCommand : Command<IPlayer>
    {
        public WalkRightCommand(IPlayer player) : base(player)
        {

        }

        public override void Execute()
        {
            Receiver.WalkRight();
        }
    }
}
