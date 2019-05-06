namespace SuperMarioBrosClone
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
