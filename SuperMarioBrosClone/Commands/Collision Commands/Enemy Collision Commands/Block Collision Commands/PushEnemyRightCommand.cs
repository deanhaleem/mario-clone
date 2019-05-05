﻿namespace SuperMarioBrosClone
{
    internal class PushEnemyRightCommand : Command<EnemyBlockCollisionHandler>
    {
        public PushEnemyRightCommand(IEnemy enemy, IBlock block, ICollision collision) :
            base(new EnemyBlockCollisionHandler(enemy, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftEnemyBlockCollision();
        }
    }
}
