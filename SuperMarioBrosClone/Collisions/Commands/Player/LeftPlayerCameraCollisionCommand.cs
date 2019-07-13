using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class LeftPlayerCameraCollisionCommand : Command<PlayerCameraCollisionHandler>
    {
        public LeftPlayerCameraCollisionCommand(IPlayer player, ICollision collision) :
            base(new PlayerCameraCollisionHandler(player, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftPlayerCameraCollision();
        }
    }
}
