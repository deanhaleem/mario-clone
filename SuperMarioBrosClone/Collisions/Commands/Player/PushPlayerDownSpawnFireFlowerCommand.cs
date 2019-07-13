using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class PushPlayerDownSpawnFireFlowerCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerDownSpawnFireFlowerCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomNonSmallPlayerPowerUpBlockCollision();
        }
    }
}
