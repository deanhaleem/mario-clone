namespace SuperMarioBrosClone
{
    internal class RightEnemyCameraCollisionCommand : Command<EnemyCameraCollisionHandler>
    {
        public RightEnemyCameraCollisionCommand(IEnemy enemy) :
            base(new EnemyCameraCollisionHandler(enemy))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightEnemyCameraCollision();
        }
    }
}
