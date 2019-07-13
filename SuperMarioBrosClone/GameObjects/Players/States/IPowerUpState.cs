namespace SuperMarioBrosClone.GameObjects.Players.States
{
    public interface IPowerUpState : IUpdatable, ITransformable
    {
        void Attack();
    }
}
