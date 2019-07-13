using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Player
{
    internal class TurnBlinkingMarioBigCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnBlinkingMarioBigCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBlinkingPlayerRedMushroomCollision();
        }
    }
}
