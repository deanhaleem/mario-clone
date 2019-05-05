namespace SuperMarioBrosClone
{
    public interface IProjectileState : IUpdatable
    {
        void Destroy();
        void Land();
    }
}
