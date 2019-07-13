using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Blocks;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class WarpRightCommand : Command<PlayerWarpPipeCollisionHandler>
    {
        public WarpRightCommand(IPlayer player, Pipe pipe) :
            base(new PlayerWarpPipeCollisionHandler(player, pipe))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerWarpPipeCollision();
        }
    }
}
