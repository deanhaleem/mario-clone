namespace SuperMarioBrosClone
{
    internal abstract class DeadEnemyState : EnemyState
    {
        protected DeadEnemyState(IEnemy enemy) : base(enemy)
        {
            Game1.Instance.UnregisterGameObject(enemy);
        }

        public override void Stomp() { }
        public override void Flip() { }
    }
}
