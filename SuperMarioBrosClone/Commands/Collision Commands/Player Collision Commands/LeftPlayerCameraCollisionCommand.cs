namespace SuperMarioBrosClone
{
    internal class LeftPlayerCameraCollisionCommand : Command<PlayerCameraCollisionHandler>
    {
        public LeftPlayerCameraCollisionCommand(IPlayer player, ICollision collision) :
            base(new PlayerCameraCollisionHandler(player, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftPlayerCameraCollision();
        }
    }
}
