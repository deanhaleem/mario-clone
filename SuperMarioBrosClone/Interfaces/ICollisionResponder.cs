namespace SuperMarioBrosClone
{
    public interface ICollisionResponder
    {
        void RespondToCollision(ICollidable collisionInstigator, ICollidable collisionReceiver, ICollision collisionSide);
    }
}
