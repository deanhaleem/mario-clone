using System;

namespace SuperMarioBrosClone
{
    public interface IItemContainer : IBlock
    {
        Type ItemType { get; set; }
    }
}
