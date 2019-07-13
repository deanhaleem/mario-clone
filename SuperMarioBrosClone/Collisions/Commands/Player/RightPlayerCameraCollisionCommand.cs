using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class RightPlayerCameraCollisionCommand : Command<PlayerCameraCollisionHandler>
    {
        public RightPlayerCameraCollisionCommand(IPlayer player, ICollision collision) :
            base(new PlayerCameraCollisionHandler(player, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerCameraCollision();
        }
    }
}
