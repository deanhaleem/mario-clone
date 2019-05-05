namespace SuperMarioBrosClone
{
    internal class PushItemUpCommand : Command<ItemBlockCollisionHandler>
    {
        public PushItemUpCommand(IItem item, IBlock block, ICollision collision) :
            base(new ItemBlockCollisionHandler(item, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopItemBlockCollision();
        }
    }
}
