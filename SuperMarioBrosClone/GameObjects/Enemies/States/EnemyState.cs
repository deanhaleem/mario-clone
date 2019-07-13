using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects.Enemies.States
{
    internal abstract class EnemyState : IEnemyState
    {
        protected IEnemy Enemy { get; }

        protected EnemyState(IEnemy enemy)
        {
            this.Enemy = enemy;
        }

        public virtual void Stomp()
        {
            Enemy.EnemyState = new StompedEnemyState(Enemy);
        }

        public virtual void Flip()
        {
            Enemy.EnemyState = new FlippedEnemyState(Enemy);
        }

        public virtual void Disarm()
        {
            Enemy.EnemyState = new ShellEnemyState(Enemy);
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void ChangeDirection() { }
        public virtual void WakeUp() { }
    }
}
