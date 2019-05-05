﻿namespace SuperMarioBrosClone
{
    internal class PushLeftOrDamagePlayerCommand : Command<PlayerEnemyCollisionHandler>
    {
        public PushLeftOrDamagePlayerCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerShellCollision();
        }
    }
}
