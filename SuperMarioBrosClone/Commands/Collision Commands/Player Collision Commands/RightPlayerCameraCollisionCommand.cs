namespace SuperMarioBrosClone
{
    internal class RightPlayerCameraCollisionCommand : Command<PlayerCameraCollisionHandler>
    {
        public RightPlayerCameraCollisionCommand(IPlayer player, ICollision collision) :
            base(new PlayerCameraCollisionHandler(player, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerCameraCollision();
        }
    }
}
