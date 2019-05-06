namespace SuperMarioBrosClone
{
    internal class PushItemLeftCommand : Command<ItemBlockCollisionHandler>
    {
        public PushItemLeftCommand(IItem item, IBlock block, ICollision collision) :
            base(new ItemBlockCollisionHandler(item, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightItemBlockCollision();
        }
    }
}
