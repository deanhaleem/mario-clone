using SuperMarioBrosClone.GameObjects.Projectiles;

namespace SuperMarioBrosClone.GameObjects
{
    public interface IProjectile : IGameObject, IRigidBody
    {
        IProjectileState ProjectileState { get; set; }
        void Destroy();
    }
}
