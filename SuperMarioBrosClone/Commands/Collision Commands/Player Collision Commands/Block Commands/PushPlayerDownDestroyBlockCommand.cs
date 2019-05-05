namespace SuperMarioBrosClone
{
    internal class PushPlayerDownDestroyBlockCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerDownDestroyBlockCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleDestroyingPlayerBlockCollision();
        }
    }
}
