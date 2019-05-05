namespace SuperMarioBrosClone
{
    internal class PushItemRightCommand : Command<ItemBlockCollisionHandler>
    {
        public PushItemRightCommand(IItem item, IBlock block, ICollision collision) :
            base(new ItemBlockCollisionHandler(item, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftItemBlockCollision();
        }
    }
}
