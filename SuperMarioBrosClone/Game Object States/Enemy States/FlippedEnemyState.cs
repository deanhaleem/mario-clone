﻿namespace SuperMarioBrosClone
{
    internal class FlippedEnemyState : DeadEnemyState
    {
        public FlippedEnemyState(IEnemy enemy) : base(enemy)
        {
            base.Enemy.ApplyImpulse(Physics.FlippedEnemyImpulse);
            base.Enemy.ApplyForce(Physics.GravitationalForce);
            base.Enemy.SetMaxVelocity(Physics.FlippedEnemyMaxVelocity);
        }
    }
}
