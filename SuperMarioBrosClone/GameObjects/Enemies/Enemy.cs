using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Enemies.States;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Enemies
{
    internal abstract class Enemy : KinematicGameObject, IEnemy
    {
        private IEnemyState enemyState;

        protected override string SpriteName => Direction + enemyState.GetType().Name + GetType().Name;

        public IEnemyState EnemyState
        {
            get => enemyState;
            set
            {
                enemyState = value;
                SetSprite();
            }
        }

        protected Enemy(Vector2 location, Color color) : base(location, color, Physics.MaxEnemyVelocity)
        {
            this.enemyState = new SleepingEnemyState(this);

            base.Direction = Directions.Left;
        }

        public override void Update(GameTime gameTime)
        {
            enemyState.Update(gameTime);

            base.Update(gameTime);
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
