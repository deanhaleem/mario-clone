﻿namespace SuperMarioBrosClone
{
    internal class PushEnemyUpOtherDownCommand : Command<EnemyEnemyCollisionHandler>
    {
        public PushEnemyUpOtherDownCommand(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision) :
            base(new EnemyEnemyCollisionHandler(instigatingEnemy, receivingEnemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomEnemyEnemyCollision();
        }
    }
}