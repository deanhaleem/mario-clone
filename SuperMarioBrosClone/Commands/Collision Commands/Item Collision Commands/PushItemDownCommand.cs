namespace SuperMarioBrosClone
{
    internal class PushItemDownCommand : Command<ItemBlockCollisionHandler>
    {
        public PushItemDownCommand(IItem item, IBlock block, ICollision collision) :
            base(new ItemBlockCollisionHandler(item, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomItemBlockCollision();
        }
    }
}
