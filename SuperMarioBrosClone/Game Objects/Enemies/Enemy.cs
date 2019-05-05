using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class Enemy : KinematicGameObject, IEnemy
    {
        private IEnemyState enemyState;

        public virtual IEnemyState EnemyState
        {
            get => enemyState;
            set
            {
                enemyState = value;
                SetSprite(enemyState.GetType().Name + GetType().Name);
            }
        }

        protected Enemy(Vector2 location, Color color) : base(location, color, Physics.MaxEnemyVelocity)
        {
            this.enemyState = new SleepingEnemyState(this);

            base.SetSprite(enemyState.GetType().Name + GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            enemyState.Update(gameTime);

            base.Update(gameTime);
        }

        public override void ChangeDirection()
        {
            EnemyState.ChangeDirection();

            base.ChangeDirection();
        }

        public virtual void Stomp()
        {
            enemyState.Stomp();
        }

        public virtual void Flip()
        {
            enemyState.Flip();
        }

        public virtual void Disarm()
        {
            enemyState.Disarm();
        }

        public virtual void WakeUp()
        {
            enemyState.WakeUp();
        }
    }
}
