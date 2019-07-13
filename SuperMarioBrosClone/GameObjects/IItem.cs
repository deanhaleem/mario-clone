using SuperMarioBrosClone.GameObjects.Items;

namespace SuperMarioBrosClone.GameObjects
{
    public interface IItem : IGameObject, IRigidBody
    {
        IItemState ItemState { get; set; }
    }
}
