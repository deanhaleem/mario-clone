using System.Collections.ObjectModel;

namespace SuperMarioBrosClone
{
    public interface ICollisionManager
    {
        void Update(ICamera camera);
        void ManageCollisions(IRigidBody collisionInstigator, ICollidable collisionReceiver);
        void ManageCameraCollisions(IRigidBody collisionInstigator, ICollidable camera);
        void ManageBlockCollisions(IRigidBody collisionInstigator, Collection<IGameObject> blocks);
        void ManagePlayerPipeCollisions(IPlayer player, IPipe pipe);
    }
}
