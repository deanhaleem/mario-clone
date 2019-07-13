using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class WarpUpCommand : Command<PlayerWarpPipeCollisionHandler>
    {
        public WarpUpCommand(IPlayer player, IPipe pipe) :
            base(new PlayerWarpPipeCollisionHandler(player, pipe))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomPlayerWarpPipeCollision();
        }
    }
}
