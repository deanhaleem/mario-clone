﻿namespace SuperMarioBrosClone
{
    internal class PushRightOrKillEnemyCommand : Command<EnemyEnemyCollisionHandler>
    {
        public PushRightOrKillEnemyCommand(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision) :
            base(new EnemyEnemyCollisionHandler(instigatingEnemy, receivingEnemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftEnemyShellCollision();
        }
    }
}
