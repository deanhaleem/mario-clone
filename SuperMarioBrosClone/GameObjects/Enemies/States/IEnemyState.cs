namespace SuperMarioBrosClone.GameObjects.Enemies.States
{
    public interface IEnemyState : IUpdatable
    {
        void ChangeDirection();
        void Stomp();
        void Flip();
        void Disarm();
        void WakeUp();
    }
}
