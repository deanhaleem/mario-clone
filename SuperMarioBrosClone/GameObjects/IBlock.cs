using SuperMarioBrosClone.GameObjects.Blocks.States;

namespace SuperMarioBrosClone.GameObjects
{
    public interface IBlock : IGameObject
    {
        IBlockState BlockState { get; set; }
        void Bump();
        void Destroy();
    }
}
