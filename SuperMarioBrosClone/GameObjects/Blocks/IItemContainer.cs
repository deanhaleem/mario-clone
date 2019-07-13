using System;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    public interface IItemContainer : IBlock
    {
        Type ItemType { get; set; }
    }
}
