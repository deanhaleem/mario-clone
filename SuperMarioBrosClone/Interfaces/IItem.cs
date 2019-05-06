namespace SuperMarioBrosClone
{
    public interface IItem : IGameObject, IRigidBody
    {
        IItemState ItemState { get; set; }
    }
}
