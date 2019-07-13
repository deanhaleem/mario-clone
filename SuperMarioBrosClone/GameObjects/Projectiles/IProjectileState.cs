namespace SuperMarioBrosClone.GameObjects.Projectiles
{
    public interface IProjectileState : IUpdatable
    {
        void Destroy();
        void Land();
    }
}
