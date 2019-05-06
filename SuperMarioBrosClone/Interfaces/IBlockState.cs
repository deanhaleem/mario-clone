namespace SuperMarioBrosClone
{
    public interface IBlockState : IUpdatable
    {
        void Bump();
        void Destroy();
    }
}
