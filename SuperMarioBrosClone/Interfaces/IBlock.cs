namespace SuperMarioBrosClone
{
    public interface IBlock : IGameObject
    {
        IBlockState BlockState { get; set; }
        void Bump();
        void Destroy();
    }
}
