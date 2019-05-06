namespace SuperMarioBrosClone
{
    internal class PushPlayerDownBumpBlockCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerDownBumpBlockCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomPlayerBlockCollision();
        }
    }
}
