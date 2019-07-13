using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class TurnBlinkingMarioStarCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnBlinkingMarioStarCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBlinkingPlayerStarCollision();
        }
    }
}
