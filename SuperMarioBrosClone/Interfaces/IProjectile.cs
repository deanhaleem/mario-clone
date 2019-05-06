namespace SuperMarioBrosClone
{
    public interface IProjectile : IGameObject, IRigidBody
    {
        IProjectileState ProjectileState { get; set; }
        void Destroy();
    }
}
