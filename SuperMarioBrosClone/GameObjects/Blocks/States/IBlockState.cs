namespace SuperMarioBrosClone.GameObjects.Blocks.States
{
    public interface IBlockState : IUpdatable
    {
        void Bump();
        void Destroy();
    }
}
