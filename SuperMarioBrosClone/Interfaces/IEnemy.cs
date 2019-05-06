namespace SuperMarioBrosClone
{
    public interface IEnemy : IGameObject, IRigidBody
    {
        IEnemyState EnemyState { get; set; }
        void Stomp();
        void Flip();
        void Disarm();
        void WakeUp();
    }
}
