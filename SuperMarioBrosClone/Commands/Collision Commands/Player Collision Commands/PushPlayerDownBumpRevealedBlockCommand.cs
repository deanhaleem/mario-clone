namespace SuperMarioBrosClone
{
    internal class PushPlayerDownBumpRevealedBlockCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerDownBumpRevealedBlockCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomPlayerHiddenBlockCollision();
        }
    }
}
